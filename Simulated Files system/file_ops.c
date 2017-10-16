#include <stdlib.h>
#include <string.h>
#include "file_ops.h"
#include "free_list.h"

/* You must not modify code already existing in this file. Your
 * code must interact with the reference implementation provided
 * here without requiring any changes to it */

/* Return a pointer to the array of Inodes that is read from the simulated
 * file system.
 * Notes:
 *  - The caller of this function must remember to free the memory that
 *    is returned.
 *  - The function is static because it is used only by other functions
 *    in this file.
 */
static Inode *read_metadata(FS *fs) {
    size_t numread;
    if (fseek(fs->fp, 0, SEEK_SET) == -1) {
        perror("read_metadata:");
        exit(1);
    }
    numread = fread(fs->metadata, sizeof(Inode), MAXFILES, fs->fp);
    if (numread < MAXFILES) {
        perror("read_metadata:");
        exit(1);
    }
    return fs->metadata;
}

/* Write the array of Inodes to the simulated file system.
 */
static void write_metadata(FS *fs) {
    size_t numwritten;
    if (fseek(fs->fp, 0, SEEK_SET) == -1) {
        perror("write_metadata:");
        exit(1);
    }
    numwritten = fwrite(fs->metadata, sizeof(Inode), MAXFILES, fs->fp);
    if (numwritten < MAXFILES) {
        perror("write_metadata:");
        exit(1);
    }
}

/* Return the index into the metadata array for the Inode that contains
 * the file named filename.  Return -1 if the file is not found.
 */
static int find_inode(Inode *metadata, char *filename) {
    int i;
    for (i = 0; i < MAXFILES; i++) {
        if ((strcmp(metadata[i].name, filename)) == 0) {
            return i;
        }
    }
    return -1;
}

/* Initialize the simulated file system by writing the metadata to the file 
 * indicating that the file system is empty.
 * Input : a pointer to char array, filename[]
 * Return : a pointer to File System Structure
 * 
 */
FS *init_fs(char *filename) {
    int i;
    char buf[MAX_FS_SIZE]; // Used to store the file system data in memory.

    FS *fs = malloc(sizeof(FS));
    if (fs == NULL) {
        perror("init_fs:");
        exit(1);
    } 

    // open the file that will hold the file system data
    fs->fp = fopen(filename, "w+");
    //"w+" Create an empty file for both reading and writing. 
    //If a file with the same name already exists its content is erased and the file is treated as a new empty file. 
    if (fs->fp == NULL) {
        perror("init_fs:");
        exit(1);
    }

    // Initialize the metadata array and write it to the file
    for (i = 0; i < MAXFILES; i++) {
        fs->metadata[i].name[0] = '\0'; //Give the name an empty string
        fs->metadata[i].offset = -1; // Initialize to an invalid offset
        fs->metadata[i].length = -1; // Initialize to an invalid length
    }
    write_metadata(fs);

    // Fill up the data area with . so that the real file has the correct size
    memset(buf, '.', MAX_FS_SIZE);  // 1024 of '.' 
    // size_t fwrite ( const void * ptr, size_t size, size_t count, FILE * stream ); 
    if (fwrite(buf, MAX_FS_SIZE, 1, fs->fp) < 1) {
        perror("init_fs:");
        exit(1);
    }

    fs->freelist = NULL;
    // METADATA_ENDS = (int)(sizeof(Inode) * MAXFILES);
    // MAX_FS_SIZE = 1024
    add_free_block(fs, METADATA_ENDS, MAX_FS_SIZE);

    return fs;
}

/* Opens an existing real file containing a file_system
 * and returns a properly initialized metadata struct
 */
FS *open_fs(char *filename) {
    FS *fs = malloc(sizeof(FS));
    if (fs == NULL) {
        perror("open_fs:");
        exit(1);
    } 

    fs->fp = fopen(filename, "r+");
    if (fs->fp == NULL) {
        perror("open_fs:");
        exit(1);
    }
    
    read_metadata(fs);
    /* TODO: Implement the following function, and uncomment the next 
     * line when you are ready to test it.
     */
    //rebuild_freelist(fs);
    return fs;
}

/* Commits to its file an existing real file system,
 * and discards the in-memory state
 */
void close_fs(FS *fs) {
    write_metadata(fs);
    fclose(fs->fp);
    
    /* TODO:  Memory needs to be freed before exiting. Write the code
     * to do this
     */

    //free(fs)
}

/* Print the contents of the simulated file system to stdout.
 */
void print_fs(FS *fs) {
    int i;
    char buf[READSIZE];
    int numread;
    int linecount = 0;

    printf("Metadata:\n");

    for (i = 0; i < MAXFILES; i++) {
        printf("%d %-24s %d %d\n", i, fs->metadata[i].name, 
                fs->metadata[i].offset, fs->metadata[i].length);
    }
    printf("\n");
        //if fseek error occurs it returns -1 (set by ferror) 
        if (fseek(fs->fp, METADATA_ENDS, SEEK_SET) == -1) {
        perror("print_fs:");
        exit(1);
    }

    // fread: Reads an array of count elements, 
    // each one with a size of size bytes, 
    // from the stream and stores them in the block of memory specified by ptr.
    while((numread = fread(buf, 1, READSIZE, fs->fp)) > 0) {
        printf("[%d] ", linecount);
        fwrite(buf, numread, 1, stdout);
        fprintf(stdout, "\n");
        linecount++;
    }
}


/* Initialize metadata for a file. No space allocated to it yet
 */
void create_file(FS *fs, char *filename, int size, char *buf) {
    int i;
    for (i = 0; i < MAXFILES; i++) {
        if (fs->metadata[i].offset < 0) {
            fs->metadata[i].offset = 0;
            fs->metadata[i].length = 0;
            strncpy(fs->metadata[i].name, filename, MAXNAME);
            break;
        }
    }
    if(i == MAXFILES) {
        fprintf(stderr, "Error: too many files.  Could not create %s\n", 
                filename);
        return;
    }

    /* TODO: Complete this function to
        - find an approrpriate free block which sets the offset
        while (fs->freelist!=NULL){
            compare size and freeblock length
            if size < freeblock length 
                found the appropriate block
            else
                ->next
        }
        - writes the simulated data to the real file at the offset
        (tip: use fwrite)
        size_t fwrite ( const void * ptr, size_t size, size_t count, FILE * stream );
        fwrite Write block of data to stream
        fwrite (buf, size, 1, fs->fp + shift );
        - updates the offset in the metadata

     */

    
    fs->metadata[i].length = size;
    write_metadata(fs);
}

/* Remove metadata for this file, and return allocated space to free list
 */
void delete_file(FS *fs, char *filename) {
    int index = find_inode(fs->metadata, filename);

    if (index == -1) {
        fprintf(stderr, "Error: file %s does not exist\n", filename);
        return;
    }

    /* TODO: Give back the free space to the freelist */
    // add free block at i-th element in the linked list
    add_free_block(fs, fs->metadata[index].offset, fs->metadata[index].length);


    // Update the metadata
    fs->metadata[index].name[0] = '\0';
    fs->metadata[index].offset = -1;
    fs->metadata[index].length = -1;
    write_metadata(fs);
}
