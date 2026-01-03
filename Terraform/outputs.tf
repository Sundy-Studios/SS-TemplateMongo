output "sumo_http_url" {
  description = "HTTP source URL for logging from this service"
  value       = sumologic_http_source.http_source.url
}
