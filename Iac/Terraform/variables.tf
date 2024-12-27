variable "location" {
  default = "East US"
  description = "Azure region for the deployment"
}

variable "sql_admin_username" {
  description = "SQL Server admin username"
}

variable "sql_admin_password" {
  description = "SQL Server admin password"
}

variable "frontend_repo_url" {
  description = "GitHub repo URL for the frontend app"
}

variable "frontend_repo_branch" {
  default = "main"
  description = "Branch to deploy the frontend app from"
}