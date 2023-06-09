﻿using System;
using Microsoft.Extensions.Configuration;

namespace BuildingBlocks.Infrastructure.Configuration
{
    public static class MinioExtensions
    {
        private const string DefaultMinioScheme = "http";
        private const string DefaultMinioHost = "localhost";
        private const int DefaultMinioPort = 9000;
        private const string DefaultMinioUserName = "admin";
        private const string DefaultMinioPassword = "password";
        private const bool DefaultMinioTraceEnabled = false;

        private static string GetMinioScheme(this IConfiguration configuration) => 
            configuration.GetString("SAAS_INFRA_MINIO_SCHEME", DefaultMinioScheme);
        
        public static string GetMinioHost(this IConfiguration configuration) => 
            configuration.GetString("SAAS_INFRA_MINIO_HOST", DefaultMinioHost);
        
        public static int GetMinioPort(this IConfiguration configuration) => 
            configuration.GetInt("SAAS_INFRA_MINIO_PORT", DefaultMinioPort);
        
        public static string GetMinioAccessKey(this IConfiguration configuration) => 
            configuration.GetString("SAAS_INFRA_MINIO_ACCESS_KEY", DefaultMinioUserName);
        
        public static string GetMinioSecretKey(this IConfiguration configuration) => 
            configuration.GetString("SAAS_INFRA_MINIO_SECRET_KEY", DefaultMinioPassword);
        
        public static bool GetMinioTraceEnabled(this IConfiguration configuration) => 
            configuration.GetBool("SAAS_INFRA_MINIO_TRACE_ENABLED", DefaultMinioTraceEnabled);

        public static Uri GetMinioUri(this IConfiguration configuration)
        {
            var scheme = configuration.GetMinioScheme();
            var host = configuration.GetMinioHost();
            var port = configuration.GetMinioPort();
            return new Uri($"{scheme}://{host}:{port}");
        }
    }
}