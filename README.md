# Robocode MCP Demo (.NET 10)

This is a **Proof of Concept (PoC)** bridge between a .NET 10 console application and the **@letoribo/mcp-graphql-enhanced** server. It demonstrates seamless integration with a Graph database via MCP.

## 🚀 Quick Start

1. **Start the MCP Server** (in a separate terminal):
   ```bash
   ENABLE_HTTP=true npx @letoribo/mcp-graphql-enhanced
   ```

2. **Run the .NET Bridge**:
   ```bash
   dotnet run
   ```

## 📊 Integration Proof (Output)

When successful, the bridge fetches and parses the GraphQL schema, displaying available graph types:

```text
🚀 [C# Bridge] Fetching Graph Schema...

✅ AVAILABLE GRAPH TYPES:
  - Guild
  - Channel
  - Message
  - User
  - Thread
  - [and other system types...]
```

## 🛠 Tech Stack
- **Runtime**: .NET 10.0.201 (WSL/Ubuntu)
- **Protocol**: JSON-RPC over HTTP
- **Source**: @letoribo/mcp-graphql-enhanced
- **Language**: C# with System.Text.Json parsing
