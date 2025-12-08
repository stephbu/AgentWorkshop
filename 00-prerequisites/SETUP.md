# Workshop Prerequisites & Setup

## Pre-Workshop Checklist

Before the workshop begins, ensure you have completed ALL items below:

- [ ] Visual Studio Code installed (latest stable version)
- [ ] .NET SDK 8.0 or later installed
- [ ] GitHub Copilot extension installed in VS Code
- [ ] GitHub EMU account provisioned
- [ ] Copilot license assigned to your EMU account
- [ ] Git configured with your EMU credentials

---

## Detailed Setup Instructions

### 1. Install Visual Studio Code

**Download:** https://code.visualstudio.com/

**Verify installation:**
```bash
code --version
```

Should display version 1.85 or later.

---

### 2. Install .NET SDK

**Download:** https://dotnet.microsoft.com/download

Install .NET 8.0 SDK (or later).

**Verify installation:**
```bash
dotnet --version
```

Should display 8.0.x or later.

**Additional verification:**
```bash
dotnet --list-sdks
```

You should see at least one SDK version 8.0.x or higher.

---

### 3. Install GitHub Copilot Extension

**In VS Code:**

1. Open Extensions view (`Cmd+Shift+X` on macOS, `Ctrl+Shift+X` on Windows/Linux)
2. Search for "GitHub Copilot"
3. Install both:
   - **GitHub Copilot** (by GitHub)
   - **GitHub Copilot Chat** (by GitHub)
4. Reload VS Code if prompted

**Verify installation:**
- Look for the Copilot icon in the status bar (bottom right)
- Open Command Palette (`Cmd+Shift+P` / `Ctrl+Shift+P`)
- Type "Copilot" - you should see Copilot commands

---

### 4. GitHub EMU Setup

Your organization should have provisioned a GitHub Enterprise Managed User (EMU) account for you.

**You'll receive:**
- EMU username (typically: `<alias>_microsoft`)
- Initial setup instructions from your GitHub admin
- Access to your organization's GitHub EMU instance

**Complete EMU onboarding:**
1. Follow the invitation link from your admin
2. Set up MFA/2FA as required
3. Complete SSO authentication

---

### 5. Authenticate Copilot with GitHub EMU

**In VS Code:**

1. Click the Copilot icon in status bar
2. Select "Sign in to GitHub"
3. Follow the browser authentication flow
4. **Important:** Authenticate with your EMU account (not personal GitHub)
5. Complete SSO if prompted
6. Authorize the GitHub Copilot application

**Verify authentication:**
- Copilot icon should no longer be grayed out
- Hover over Copilot icon - should show "GitHub Copilot: Ready"

---

### 6. Enable Agent Mode

**In VS Code:**

1. Open Copilot Chat panel:
   - Click chat icon in activity bar (left side), OR
   - Press `Cmd+Shift+I` (macOS) / `Ctrl+Shift+I` (Windows/Linux)

2. Look for the agent mode toggle in the chat interface
   - May appear as a sparkle icon, "Agent" button, or similar
   - If you don't see it, ensure extensions are up to date

**Verify agent mode:**
- Try a simple prompt like: "Create a new C# class called Hello"
- Agent mode should show file creation/edit capabilities

---

### 7. Git Configuration (EMU)

Configure Git with your EMU credentials:

```bash
git config --global user.name "Your Name"
git config --global user.email "your_emu_username@company.com"
```

**Set up credential helper:**

macOS:
```bash
git config --global credential.helper osxkeychain
```

Windows:
```bash
git config --global credential.helper manager
```

Linux:
```bash
git config --global credential.helper cache
```

**Test authentication:**
```bash
gh auth login
```

Select:
- GitHub.com
- HTTPS
- Login with your EMU credentials
- Complete web-based authentication

**Verify:**
```bash
gh auth status
```

Should show you're logged in to your EMU organization.

---

## Final Verification Checklist

Run these commands to verify your setup:

```bash
# Check versions
code --version
dotnet --version
git --version

# Check Copilot authentication
gh auth status

# Create a test .NET project
mkdir ~/copilot-test
cd ~/copilot-test
dotnet new console
code .
```

In VS Code:
1. Open the `Program.cs` file
2. Open Copilot Chat (`Cmd+Shift+I` / `Ctrl+Shift+I`)
3. Type: "Add a method that prints Hello World"
4. Verify Copilot responds and suggests code

If all of the above works, you're ready! 🎉

---

## Common Issues

See [TROUBLESHOOTING.md](./TROUBLESHOOTING.md) if you encounter problems.

---

## 7. Model Context Protocol (MCP) Servers (Optional)

MCP servers extend GitHub Copilot's capabilities by connecting to external systems like GitHub Issues and Azure DevOps.

### What is MCP?

Model Context Protocol enables AI agents to:
- Read and write GitHub Issues
- Create and update Azure DevOps work items
- Access project management data from within VS Code
- Automatically update tasks based on code changes

**Benefits for development:**
- Update work items as you implement features
- Link code to requirements automatically
- Maintain traceability between issues and implementation
- Reduce context switching between tools

### Installing MCP Servers

**For GitHub Integration:**

1. Install the GitHub MCP server extension:
   ```bash
   code --install-extension github.copilot-mcp-github
   ```

2. Configure GitHub access:
   - Open VS Code Settings (`Cmd+,` / `Ctrl+,`)
   - Search for "MCP GitHub"
   - Add your GitHub EMU PAT (Personal Access Token)
   
3. Create GitHub PAT:
   - Go to GitHub EMU → Settings → Developer settings → Personal access tokens
   - Click "Generate new token (classic)"
   - Required scopes: `repo`, `read:org`, `write:discussion`
   - Copy token and save securely

**For Azure DevOps Integration:**

1. Install the Azure DevOps MCP server:
   ```bash
   npm install -g @microsoft/mcp-server-ado
   ```

2. Configure ADO access:
   - Create ADO Personal Access Token at: https://dev.azure.com/[org]/_usersSettings/tokens
   - Required scopes: `Work Items (Read, Write)`
   - Add to VS Code settings:
   
   ```json
   "mcp.servers": {
     "ado": {
       "command": "mcp-server-ado",
       "env": {
         "ADO_ORG": "your-org-name",
         "ADO_PROJECT": "your-project-name",
         "ADO_PAT": "your-personal-access-token"
       }
     }
   }
   ```

### Using MCP in Agent Mode

Once configured, you can:

**Query GitHub Issues:**
```
@workspace Show me all open issues labeled "bug" in this repository
```

**Create GitHub Issues:**
```
Create a GitHub issue titled "Add user authentication" with description 
from requirements/auth-requirements.md
```

**Update Azure DevOps tasks:**
```
Update ADO task #12345 to status "In Progress" and add comment 
"Implemented authentication service"
```

**Link code to work items:**
```
Find all ADO tasks related to authentication and link them 
to the commits I just made
```

### Verification

**Test GitHub MCP:**
```
@workspace List the last 5 issues in this repository
```

**Test ADO MCP:**
```
@workspace Show me my assigned work items in ADO
```

If successful, you'll see live data from your systems.

**Note:** MCP servers are optional for this workshop but highly recommended for production use.

---

## What to Bring to the Workshop

- Laptop with all software installed ✅
- Charger (important!)
- Notepad/pen for notes (optional)
- Your curiosity and questions!

---

## Optional: Familiarize Yourself

If you have time before the workshop, try:

1. **Play with Copilot completions**
   - Start typing a C# method and see inline suggestions
   - Press `Tab` to accept suggestions

2. **Try Copilot Chat**
   - Ask questions about C# syntax
   - Ask it to explain existing code

3. **Experiment with agent mode**
   - Try: "Create a C# class with properties for a Person"
   - Observe how it creates/modifies files

Don't worry if you're not comfortable yet - that's what the workshop is for!

---

## Questions?

Contact the workshop facilitator before the session if you have setup issues:
- [Facilitator contact info]

See you at the workshop! 🚀
