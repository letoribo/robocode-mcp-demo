using System;
using System.Net.Http.Json;
using System.Text.Json;

// Initialize HTTP client for MCP communication
using var client = new HttpClient();
Console.WriteLine("🚀 [C# Bridge] Fetching Graph Schema...");

// Define JSON-RPC payload for GraphQL introspection
var payload = new { 
    jsonrpc = "2.0", 
    method = "query-graphql", 
    @params = new { query = "query { __schema { types { name } } }" }, 
    id = 1 
};

try {
    // Send POST request to the local MCP server (default port 6274)
    var response = await client.PostAsJsonAsync("http://localhost:6274/mcp", payload);
    var doc = await response.Content.ReadFromJsonAsync<JsonElement>();
    
    // Extract nested JSON string from MCP 'text' content
    // Added '!' to suppress nullability warnings as we expect valid data
    string? innerJson = doc.GetProperty("result").GetProperty("content")[0].GetProperty("text").GetString();
    
    if (!string.IsNullOrEmpty(innerJson)) {
        var resultData = JsonDocument.Parse(innerJson);
        var types = resultData.RootElement.GetProperty("result").GetProperty("__schema").GetProperty("types");

        Console.WriteLine("\n✅ AVAILABLE GRAPH TYPES:");
        foreach (var type in types.EnumerateArray()) {
            Console.WriteLine($"  - {type.GetProperty("name")}");
        }
    }
} catch (Exception ex) {
    Console.WriteLine($"\n❌ COMMUNICATION ERROR: {ex.Message}");
}