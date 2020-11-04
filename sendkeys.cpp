#include <Windows.h>

__declspec(dllexport) void discord(char *str) {
    HWND d = FindWindow("Discord", NULL);
    SendMessage(d, WM_SETTEXT, NULL, (LPARAM)str);
}
