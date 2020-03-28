# Stream Deck for Visual Studio Code

## Features

- Execute any Visual Studio Code command or menu.
- Create and execute terminal commands.
- Insert snippets.

## Getting Started

1. Download _Visual Studio Code_ plugin on Stream Deck Store or [here](https://github.com/nicollasricas/vscode-streamdeck/releases/latest).
2. Download _Stream Deck for Visual Studio Code_ on [Visual Studio Code marketplace](https://marketplace.visualstudio.com/items?itemName=nicollasr.vscode-streamdeck) or [here](https://github.com/nicollasricas/vscode-streamdeck/releases/latest).

After installing the plugin and the extension you should see this in VSCode status bar:

![Connected to Stream Deck](https://user-images.githubusercontent.com/7860985/75925951-f97eaa80-5e3f-11ea-8ae2-0a1e7b838380.png)

**If for some reason the focused instance, were not active click on the status bar or alternate between windows to force activation.**

**Only the active session will receive the commands.**

## Getting Commands ID

In Visual Studio Code open _File->Preferences->Keyboard Shortcuts_, find the command you want, right-click it and _Copy Command Id_.

## Settings (Optional)

You can change the IP and port to the message server in the _settings.ini_ file.

    [general]
    host=127.0.0.1
    port=48969

#### Windows

_%appdata%\Elgato\StreamDeck\Plugins\com.nicollasr.streamdeckvsc.sdPlugin\settings.ini_

#### Mac

_~/Library/Application Support/com.elgato.StreamDeck/Plugins/com.nicollasr.streamdeckvsc.mac.sdPlugin/settings.ini_

**Don't forget to change it in Visual Studio Code settings or you won't be able to connect and use the available features.**

_I recommend using 127.0.0.1 as your IP address instead of localhost_.
