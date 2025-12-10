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

| Platform | Download | Notes |
|----------|----------|-------|
| **macOS** | Download `.dmg` or use Homebrew: `brew install --cask visual-studio-code` | Drag to Applications folder |
| **Windows** | Download `.exe` installer | Check "Add to PATH" during install |

**Verify installation:**

**macOS (Terminal):**
```bash
code --version
```

**Windows (PowerShell or Command Prompt):**
```powershell
code --version
```

Should display version 1.85 or later.

---

### 2. Clone the Workshop Repository

Clone the workshop materials to a folder in your home directory.

**macOS (Terminal):**
```bash
# Create a workshop folder in your home directory
mkdir -p ~/workshop
cd ~/workshop

# Clone the workshop repository
git clone https://github.com/stephbu/AgentWorkshop.git

# Navigate to the workshop folder
cd AgentWorkshop
```

**Windows (PowerShell):**
```powershell
# Create a workshop folder in your home directory
New-Item -ItemType Directory -Force -Path $HOME\workshop
cd $HOME\workshop

# Clone the workshop repository
git clone https://github.com/stephbu/AgentWorkshop.git

# Navigate to the workshop folder
cd AgentWorkshop
```

**Verify:**
- You should now have `~/workshop/AgentWorkshop` (macOS) or `%USERPROFILE%\workshop\AgentWorkshop` (Windows)
- The folder contains `00-prerequisites/`, `01-greenfield/`, `02-brownfield/`, and other workshop files

---

### 3. Install .NET SDK

**Download:** https://dotnet.microsoft.com/download

Install .NET 8.0 SDK (or later).

| Platform | Installation Method |
|----------|--------------------|
| **macOS** | Download `.pkg` installer or use Homebrew: `brew install dotnet-sdk` |
| **Windows** | Download `.exe` installer and run |

**Verify installation:**

**macOS (Terminal):**
```bash
dotnet --version
```

**Windows (PowerShell):**
```powershell
dotnet --version
```

Should display 8.0.x or later.

**Additional verification:**

**macOS:**
```bash
dotnet --list-sdks
```

**Windows:**
```powershell
dotnet --list-sdks
```

You should see at least one SDK version 8.0.x or higher.

---

### 4. Install GitHub Copilot Extension

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

### 5. GitHub EMU Setup

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

### 6. Authenticate Copilot with GitHub EMU

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

### 7. Enable Agent Mode

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

## Final Verification Checklist

Run these commands to verify your setup:

**macOS (Terminal):**
```bash
# Check versions
code --version
dotnet --version
git --version

# Create a test .NET project
mkdir ~/copilot-test
cd ~/copilot-test
dotnet new console
code .
```

**Windows (PowerShell):**
```powershell
# Check versions
code --version
dotnet --version
git --version

# Create a test .NET project
mkdir $HOME\copilot-test
cd $HOME\copilot-test
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

## Workshop Workspace Setup

Open the cloned workshop repository in VS Code.

### 1. Open as VS Code Workspace

**Option A: From Terminal/PowerShell**

**macOS:**
```bash
cd ~/workshop/AgentWorkshop
code .
```

**Windows:**
```powershell
cd $HOME\workshop\AgentWorkshop
code .
```

**Option B: From VS Code**

| Platform | Steps |
|----------|-------|
| **macOS** | File → Open Folder (or `Cmd+O`) → Navigate to `~/workshop/AgentWorkshop` → Click "Open" |
| **Windows** | File → Open Folder (or `Ctrl+K Ctrl+O`) → Navigate to `%USERPROFILE%\workshop\AgentWorkshop` → Click "Select Folder" |

### 2. Trust the Workspace

When prompted:
1. Click "Yes, I trust the authors"
2. This enables full VS Code functionality including extensions

### 3. Recommended Workspace Settings

Create a `.vscode/settings.json` file (if not present) with these recommended settings:

```json
{
  "editor.formatOnSave": true,
  "editor.defaultFormatter": "ms-dotnettools.csharp",
  "files.autoSave": "afterDelay",
  "files.autoSaveDelay": 1000,
  "dotnet.defaultSolution": "disable",
  "omnisharp.enableRoslynAnalyzers": true,
  "github.copilot.enable": {
    "*": true
  }
}
```

### 4. Install Recommended Extensions

The workshop may include an `.vscode/extensions.json` file. If prompted:
1. Click "Install All" when VS Code suggests recommended extensions
2. Or manually install:
   - **C# Dev Kit** (ms-dotnettools.csdevkit)
   - **GitHub Copilot** (github.copilot)
   - **GitHub Copilot Chat** (github.copilot-chat)

### 5. Verify Workspace Setup

1. Open the Explorer view (`Cmd+Shift+E` / `Ctrl+Shift+E`)
2. You should see the workshop folder structure:
   ```
   AgentWorkshop/
   ├── 00-prerequisites/
   ├── 01-greenfield/
   ├── 02-brownfield/
   ├── resources/
   └── README.md
   ```

3. Open Copilot Chat (`Cmd+Shift+I` / `Ctrl+Shift+I`)
4. Type: `@workspace What files are in this project?`
5. Copilot should list the workshop contents

### 6. Open Multiple Folders (Optional)

If working on lab exercises in separate folders:

1. File → Add Folder to Workspace
2. Select the lab folder (e.g., `01-greenfield/HighLow`)
3. Save the workspace: File → Save Workspace As...
4. Name it `AgentWorkshop.code-workspace`

This creates a multi-root workspace for easy navigation between materials and your code.

---

## Common Issues

See [TROUBLESHOOTING.md](./TROUBLESHOOTING.md) if you encounter problems.

---

## 9. Model Context Protocol (MCP) Servers (Optional)

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
