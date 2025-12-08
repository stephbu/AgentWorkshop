# Workshop Setup Troubleshooting

Common issues and solutions for workshop prerequisites.

---

## GitHub Copilot Issues

### Issue: Copilot icon is grayed out in status bar

**Possible causes:**
- Not signed in
- License not assigned
- Extension not activated

**Solutions:**

1. **Check sign-in status:**
   - Click the Copilot icon
   - If it says "Sign in", authenticate with your EMU account
   - Complete the full browser flow

2. **Verify license:**
   - Go to https://github.com/settings/copilot
   - Ensure Copilot is enabled for your EMU account
   - Contact your GitHub admin if license isn't assigned

3. **Reload VS Code:**
   ```
   Command Palette → Developer: Reload Window
   ```

4. **Check extension status:**
   - Extensions view → Search "GitHub Copilot"
   - Ensure both "GitHub Copilot" and "GitHub Copilot Chat" are installed and enabled

---

### Issue: "GitHub Copilot could not connect to server"

**Possible causes:**
- Network/proxy issues
- Firewall blocking GitHub
- EMU SSO session expired

**Solutions:**

1. **Check network connectivity:**
   ```bash
   curl -I https://api.github.com
   ```
   Should return HTTP 200.

2. **Refresh SSO session:**
   - Log out of Copilot: `Command Palette → GitHub Copilot: Sign Out`
   - Sign back in, complete SSO flow again

3. **Check proxy settings:**
   - If behind corporate proxy, configure in VS Code settings:
   ```json
   {
     "http.proxy": "http://proxy.company.com:8080",
     "http.proxyStrictSSL": false
   }
   ```

4. **Verify firewall allows:**
   - `*.github.com`
   - `*.githubusercontent.com`
   - `*.copilot-proxy.githubusercontent.com`

---

### Issue: Agent mode not available

**Possible causes:**
- Extension not updated
- Feature not rolled out to your organization
- Wrong extension version

**Solutions:**

1. **Update extensions:**
   - Extensions view → Click gear on GitHub Copilot → "Check for Updates"
   - Update to latest version
   - Reload VS Code

2. **Verify agent mode eligibility:**
   - Agent mode is generally available as of late 2024
   - Ensure your EMU organization allows the feature
   - Check with GitHub admin if unsure

3. **Try alternative access:**
   - In Copilot Chat, try typing `@workspace` before your prompt
   - This accesses similar multi-file capabilities

---

## GitHub EMU Issues

### Issue: Cannot authenticate with EMU account

**Possible causes:**
- Wrong credentials
- SSO not completed
- MFA not set up

**Solutions:**

1. **Verify EMU username:**
   - EMU usernames typically: `firstname_lastname_company`
   - NOT your personal GitHub username
   - Check invitation email from GitHub admin

2. **Complete SSO setup:**
   - Follow the complete SSO flow in browser
   - Don't skip any steps
   - Authorize all requested permissions

3. **Set up MFA:**
   - EMU accounts usually require MFA/2FA
   - Set up authenticator app or security key
   - Complete MFA enrollment before proceeding

4. **Contact your GitHub admin:**
   - Verify account is provisioned
   - Check license assignment
   - Confirm organization access

---

### Issue: `gh auth login` fails

**Possible causes:**
- GitHub CLI not installed
- Wrong authentication method
- Cached credentials conflict

**Solutions:**

1. **Install GitHub CLI:**
   ```bash
   # macOS
   brew install gh
   
   # Windows
   winget install --id GitHub.cli
   
   # Linux
   # See: https://github.com/cli/cli/blob/trunk/docs/install_linux.md
   ```

2. **Use correct flow:**
   ```bash
   gh auth logout
   gh auth login
   ```
   - Select: **GitHub.com** (not Enterprise Server)
   - Select: **HTTPS**
   - Authenticate via **browser** with EMU credentials

3. **Clear cached credentials:**
   ```bash
   # macOS
   git credential-osxkeychain erase
   # (then paste: host=github.com, press Enter twice)
   
   # Windows - use Credential Manager GUI
   
   # Linux
   git credential-cache exit
   ```

---

## .NET SDK Issues

### Issue: `dotnet: command not found`

**Solutions:**

1. **Verify installation:**
   - Download from https://dotnet.microsoft.com/download
   - Run installer
   - Close and reopen terminal

2. **Check PATH (macOS/Linux):**
   ```bash
   echo $PATH
   ```
   Should include `/usr/local/share/dotnet` or similar.
   
   If missing, add to `~/.zshrc` or `~/.bashrc`:
   ```bash
   export PATH="$PATH:/usr/local/share/dotnet"
   ```

3. **Check PATH (Windows):**
   - Search: "Environment Variables"
   - Verify `C:\Program Files\dotnet` is in PATH
   - Restart terminal after changes

---

### Issue: Wrong .NET version

**Symptom:** `dotnet --version` shows < 8.0

**Solution:**

1. **Install .NET 8.0 SDK:**
   - Download from https://dotnet.microsoft.com/download/dotnet/8.0
   - Install SDK (not just runtime)

2. **Verify multiple SDKs:**
   ```bash
   dotnet --list-sdks
   ```
   Should show 8.0.x or later

3. **Set global.json (if needed):**
   If project requires specific version:
   ```json
   {
     "sdk": {
       "version": "8.0.100"
     }
   }
   ```

---

## VS Code Issues

### Issue: VS Code won't open from terminal

**Solutions:**

1. **Install 'code' command:**
   - Open VS Code
   - Command Palette (`Cmd+Shift+P` / `Ctrl+Shift+P`)
   - Type: "Shell Command: Install 'code' command in PATH"
   - Run the command

2. **Verify installation:**
   ```bash
   which code
   code --version
   ```

---

### Issue: Extensions won't install

**Solutions:**

1. **Check extension marketplace access:**
   - Ensure firewall allows `marketplace.visualstudio.com`
   - Try disabling proxy temporarily

2. **Install manually:**
   - Download `.vsix` file from https://marketplace.visualstudio.com/
   - Extensions view → `...` menu → "Install from VSIX"

3. **Clear extension cache:**
   ```bash
   # macOS/Linux
   rm -rf ~/.vscode/extensions/*
   
   # Windows
   # Delete: %USERPROFILE%\.vscode\extensions
   ```
   Then reinstall extensions.

---

## Workshop Day Quick Fixes

### Emergency: Nothing is working

**30-second check:**
```bash
# Run all at once:
code --version && \
dotnet --version && \
gh auth status
```

**If any fail:**
1. Raise your hand - facilitator will help
2. Pair with neighbor while troubleshooting
3. Use web-based codespaces as fallback (if available)

---

### Fallback: GitHub Codespaces

If local setup fails, you can use GitHub Codespaces:

1. Go to your workshop repository on GitHub
2. Click "Code" → "Codespaces" → "Create codespace"
3. VS Code environment opens in browser
4. Copilot should work automatically (already authenticated)

**Note:** This requires your EMU account has Codespaces access.

---

## Still Stuck?

**During workshop:**
- Raise your hand
- Facilitator will provide individual assistance

**Before workshop:**
- Email facilitator: [contact info]
- Join workshop Slack/Teams channel: [link]
- Check office hours: [times]

---

## Useful Diagnostic Commands

Run these to gather info for troubleshooting:

```bash
# System info
uname -a                    # OS info
code --version              # VS Code version
dotnet --info               # .NET installation details
gh --version                # GitHub CLI version

# Authentication
gh auth status              # GitHub auth status
git config --list           # Git configuration

# VS Code extensions
code --list-extensions      # Installed extensions
```

Share this output with facilitator if you need help.

---

## Pre-Workshop Testing Script

Test everything at once:

```bash
#!/bin/bash
echo "=== Workshop Prerequisites Check ==="
echo ""

echo "1. VS Code:"
code --version && echo "✅ VS Code installed" || echo "❌ VS Code not found"
echo ""

echo "2. .NET SDK:"
dotnet --version && echo "✅ .NET SDK installed" || echo "❌ .NET SDK not found"
echo ""

echo "3. Git:"
git --version && echo "✅ Git installed" || echo "❌ Git not found"
echo ""

echo "4. GitHub CLI:"
gh --version && echo "✅ GitHub CLI installed" || echo "❌ GitHub CLI not found"
echo ""

echo "5. GitHub Authentication:"
gh auth status && echo "✅ Authenticated" || echo "❌ Not authenticated"
echo ""

echo "=== Check complete ==="
echo "If any items show ❌, see TROUBLESHOOTING.md"
```

Save as `check-setup.sh`, run with `bash check-setup.sh`
