variable "resource_group_name" {
  type        = string
  description = "Resource group name"
}

variable "resource_group_location" {
  type        = string
  description = "Location of resource group"
}

variable "app_service_plan_name" {
  type        = string
  description = "Name of app service plan"
}

variable "app_service_name" {
  type        = string
  description = "Name of app service"
}

variable "sql_service_name" {
  type        = string
  description = "Name of sql server"
}

variable "sql_database_name" {
  type        = string
  description = "Name of sql database"
}

variable "sql_admin_login" {
  type        = string
  description = "Provaded admin login name"
}

variable "sql_admin_password" {
  type        = string
  description = "Provaded admin password"
}

variable "firewall_rull_name" {
  type        = string
  description = "Name of the firewall rul"
}

variable "repo_URL" {
  type        = string
  description = "Url for the repo"
}