/* The functions operate on a linked list of free blocks.  Each node of the
 * list contains the starting location and the length of a free block.
 * 
 */

#include <string.h>
#include <stdlib.h>

#include "free_list.h"

/* Give free space back to the free list.  Since the list is ordered by 
 * location, this function is the same for both algorithms.
 */
void add_free_block(FS *fs, int location, int size) {
	return;
}

/* Print the contents of the free list */

void show_freelist(FS *fs) {
    return;
}


/* To be used after the metadata has been read from a file, to rebuild the
 * free list.
 */
void rebuild_freelist(FS *fs) {
    return;
}
