variable "sumologic_access_id" {
  type        = string
  description = "Sumo Logic Access ID (from your Sumo Logic user)"
}

variable "sumologic_access_key" {
  type        = string
  description = "Sumo Logic Access Key (from your Sumo Logic user)"
}

variable "service_name" {
  type        = string
  description = "The service name, e.g., Template, RaceHub, Tyler"
}

variable "environment" {
  type        = string
  default     = "Dev"
  description = "Environment name, e.g., Dev, Staging, Prod"
}
