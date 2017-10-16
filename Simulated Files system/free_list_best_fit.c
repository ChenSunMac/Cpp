#include <string.h>
#include <stdlib.h>

#include "free_list.h"

/* Implement the best fit algorithm to find free space for the
   simulated file data.
 */

int get_free_block(FS *fs, int size) {
	// define a NUM = 4 or 2 or ...
	// look through the list
	// find the first block with [(length - offset) - size] < NUM
	// if such block exists, use it
        return -1;
}


