output "backend_url" {
  value = azurerm_app_service.backend.default_site_hostname
}

output "frontend_url" {
  value = azurerm_static_site.frontend.default_hostname
}

output "sql_connection_string" {
  value = azurerm_sql_database.sql_db.connection_string
}