#include <Windows.h>
#include <stdio.h>
#include <stdlib.h>

void main() {
    while(true) {
        FILE *f = fopen("lol", "r");
        char kekw[1024];
        fread(kekw, 1, 1024, f);
        fclose(f);
        HWND d = FindWindow("Discord", NULL);
        SendMessage(d, WM_SETTEXT, NULL, (LPARAM)kekw);
        Sleep(60);
    }
}
