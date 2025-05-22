// MathLibrary.h - Contains declarations of math functions
#pragma once

#ifdef FOR_NPCAP_EXPORTS
#define FOR_NPCAP_API __declspec(dllexport)
#else
#define FOR_NPCAP_API __declspec(dllimport)
#endif

#include "pcap.h"

// The Fibonacci recurrence relation describes a sequence F
// where F(n) is { n = 0, a
//               { n = 1, b
//               { n > 1, F(n-2) + F(n-1)
// for some initial integral values a and b.
// If the sequence is initialized F(0) = 1, F(1) = 1,
// then this relation produces the well-known Fibonacci
// sequence: 1, 1, 2, 3, 5, 8, 13, 21, 34, ...

// Initialize a Fibonacci relation sequence
// such that F(0) = a, F(1) = b.
// This function must be called before any other function.
extern "C" FOR_NPCAP_API int send_raw_packet(
    const char* iface, const unsigned char* packet, int length);
