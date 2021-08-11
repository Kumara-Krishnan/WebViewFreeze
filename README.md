# WebViewFreeze
A minimum reproducible sample for UI freeze which occurs when closing a secondary view and focusing a content editable webview in UWP.

Issue:
In latest OS builds higher than 17763, UWP apps which uses a content editable webview freezes the UI in a particular scenario.

Prerequisites:
1. OS build version should be higher than 17763.

Steps to reproduce:
1. Launch the app and focus any textbox. Now keep tab pressed which will cause navigation across controls. Even if we keep the tab key pressed for a few seconds, it navigates between controls smoothly.
2. Then click new window button to launch a secondary view. Now close the secondary window.
3. Again, focus and textbox and keep tab key pressed. After a few seconds, UI freezes.

When trying the same in OS build version 17763, this issue doesn't occur. It works properly.

Sample video in both OS - https://workdrive.zohoexternal.com/external/35452a4cc8651089940a884cbac1cd143d514c39544fa47fdf70a62a374ab339