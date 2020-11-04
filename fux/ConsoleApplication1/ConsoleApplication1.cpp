
#define _CRT_SECURE_NO_WARNINGS

#include <Windows.h>
#include <stdio.h>
#include <stdlib.h>

#define arrsz(a, t) sizeof(a) / sizeof(t)

constexpr INPUT input_ctor(WORD vk, WORD scan, DWORD flags)
{
	INPUT i = INPUT();
	i.type = 1;
	i.ki.wVk = vk;
	i.ki.wScan = scan;
	i.ki.time = i.ki.dwExtraInfo = 0;
	i.ki.dwFlags = flags;
	return i;
}

#define type(vk, scan) \
	input_ctor(vk, scan, KEYEVENTF_UNICODE),\
	input_ctor(vk, scan, KEYEVENTF_UNICODE | KEYEVENTF_KEYUP)

int main() {
	Sleep(2000);
    while (true) {
        FILE* f = fopen("lol", "r");
		if (!f)return 1;
        char kekw[1024];
        size_t len = fread(kekw, 1, 1024, f);
        fclose(f);
		INPUT ip[2048];
		int i = 0;
		while (i < len * 2) {
			ip[i++] = input_ctor(kekw[i], kekw[i], KEYEVENTF_UNICODE);
			ip[i++] = input_ctor(kekw[i], kekw[i], KEYEVENTF_UNICODE | KEYEVENTF_KEYUP);
		}
        Sleep(6000);
    }
}
