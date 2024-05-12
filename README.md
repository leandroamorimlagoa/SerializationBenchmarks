# Serialization Benchmarks
## MessagePack VS JSON

This project provides benchmarks for comparing the serialization performance of MessagePack and JSON serializers.

## Overview

The `SerializersTelemetry` class contains benchmark methods for serializing data using MessagePack and JSON serializers. It measures the time taken for serialization and saves the serialized data to files.

## Setup

1. **General Configuration:**
   - `dbFile`: Path to the Firebird database file.
   - `connectionString`: Connection string for accessing the Firebird database.
   - `targetFolder`: Path to the folder where serialized files will be saved.
   - `query`: SQL query to retrieve data from the database table.

2. **MessagePack Configuration:**
   - `formatterResolver`: Resolver for MessagePack serialization.
   - `messagePackSerializerOptions`: Options for MessagePack serializer, including compression settings.
   - `messagePackFile`: Path to save the MessagePack serialized file.

3. **JSON Configuration:**
   - `jsonSerializerOptions`: Options for JSON serializer.
   - `jsonFile`: Path to save the JSON serialized file.

## Usage

1. Ensure that the Firebird database file path and connection string are correctly set.
2. Specify the target folder where serialized files will be saved.
3. Define the SQL query to retrieve data from the database table.
4. Run the benchmarks to measure the serialization performance.
5. Serialized files will be saved in the specified target folder.

## Benchmark Methods

1. **SerializeMessagePack():**
   - Benchmark method for serializing data using MessagePack serializer.
   - Serialized data is saved to a MessagePack file.

2. **SerializeJson():**
   - Benchmark method for serializing data using JSON serializer.
   - Serialized data is saved to a JSON file.

## Notes

- Ensure that appropriate dependencies for Firebird database access, MessagePack, and BenchmarkDotNet are installed.
- Customize the configurations and methods as per your specific requirements.
- This repository is part of a blog post about serialization benchmarks (MessagePack VS JSON). For more information, please visit the blog.

# Contacts
Email: leamorim@outlook.com 
LinkedIn: https://www.linkedin.com/in/leandrolagoa 
Blog: https://leandrolagoa.wordpress.com