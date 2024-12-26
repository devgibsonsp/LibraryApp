provider "azurerm" {
  features {}
}

# Resource Group
resource "azurerm_resource_group" "app_rg" {
  name     = "library-app-rg"
  location = var.location
}

# Azure SQL Database
resource "azurerm_sql_server" "sql_server" {
  name                         = "library-sql-server"
  resource_group_name          = azurerm_resource_group.app_rg.name
  location                     = azurerm_resource_group.app_rg.location
  administrator_login          = var.sql_admin_username
  administrator_login_password = var.sql_admin_password
  version                      = "12.0"
}

resource "azurerm_sql_database" "sql_db" {
  name                = "library-database"
  resource_group_name = azurerm_resource_group.app_rg.name
  location            = azurerm_resource_group.app_rg.location
  server_name         = azurerm_sql_server.sql_server.name
  sku_name            = "Basic"
}

# Backend App Service Plan
resource "azurerm_app_service_plan" "backend_plan" {
  name                = "library-backend-asp"
  location            = azurerm_resource_group.app_rg.location
  resource_group_name = azurerm_resource_group.app_rg.name
  sku {
    tier = "Basic"
    size = "B1"
  }
}

# Backend App Service
resource "azurerm_app_service" "backend" {
  name                = "library-backend-service"
  location            = azurerm_resource_group.app_rg.location
  resource_group_name = azurerm_resource_group.app_rg.name
  app_service_plan_id = azurerm_app_service_plan.backend_plan.id

  app_settings = {
    "ASPNETCORE_ENVIRONMENT" = "Production"
    "ConnectionStrings__Default" = azurerm_sql_database.sql_db.connection_string
  }
}

# Frontend Static Web App
resource "azurerm_static_site" "frontend" {
  name                = "library-frontend"
  location            = azurerm_resource_group.app_rg.location
  resource_group_name = azurerm_resource_group.app_rg.name
  sku                 = "Free"

  repository_url      = var.frontend_repo_url
  branch              = var.frontend_repo_branch
  output_location     = "/build"
  app_location        = "/"
  api_location        = ""
}