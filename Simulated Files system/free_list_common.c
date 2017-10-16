/* The functions operate on a linked list of free blocks.  Each node of the
 * list contains the starting location and the length of a free block.
 * 
 */
	// Insert node 
/*	node_t* insert (node_t* head, node_t* new){
		new -> next = head;
		head = new;
		return head;
	}
*/
#include <string.h>
#include <stdlib.h>

#include "free_list.h"

/* Give free space back to the free list.  Since the list is ordered by 
 * location, this function is the same for both algorithms.
 */
/* Input : - pointer to File System fs
 *		   - integer location
 * 		   - integer size of free block
 * Function : add new block in fs->freelist
 */
void add_free_block(FS *fs, int location, int size) {
	//create freeblock and its pointer

	Freeblock freeblock = {.next = NULL, .offset = location, .length = size - location}; 
	fs->freelist = insert(fs->freelist, &freeblock);

	return;
}

/* Print the contents of the free list */

void show_freelist(FS *fs) {
	while (fs->freelist!=NULL){
		printf("(offset: %d, length: %d)\n", fs->freelist->offset, fs->freelist->length);
	}
    return;
}


/* To be used after the metadata has been read from a file, to rebuild the
 * free list.
 */
void rebuild_freelist(FS *fs) {
    return;
}
