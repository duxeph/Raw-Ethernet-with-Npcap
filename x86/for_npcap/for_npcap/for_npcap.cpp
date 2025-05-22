#include "pch.h" // use stdafx.h in Visual Studio 2017 and earlier
#include "for_npcap.h"

int send_raw_packet(const char* iface, const unsigned char* packet, int length) {
    char errbuf[PCAP_ERRBUF_SIZE];
    pcap_t* handle = pcap_open_live(iface, 65536, 1, 1, errbuf);

    if (handle == NULL) {
        fprintf(stderr, "Couldn't open device %s: %s\n", iface, errbuf);
        return -1;
    }

    int result = pcap_sendpacket(handle, packet, length);
    pcap_close(handle);

    return result;
}
