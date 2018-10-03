#include "pch.h"
#include <stdio.h>
#include <stdlib.h>
#include <time.h>

int isPrime(int a);

int isPrime(int a) {
	for (int m = 2;m < a / 2;m++) {
		if (a % m == 0) {
			return 0;
		}
	}
	return 1;
}

int main(int argc, char** argv) {
	clock_t start, end;
	double cpu_time_used;
	start = clock();
	/**/
	
	/**/
	end = clock();
	cpu_time_used = ((double)(end - start)) / CLOCKS_PER_SEC;
	printf("\nExecution Time - %f \n", cpu_time_used);
	return 0;
}