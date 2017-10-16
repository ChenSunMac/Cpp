//Dynamic String - copy string directly using memory copy
char *duplicate_string(const char*s){
	size_t len = strlen(s);
	char* copied = malloc(len + 1);
	//Copy block of memory
	// void * memcpy ( void * destination, const void * source, size_t num );
	memcpy(copied, s, len+1);
	return copied;
}


/* Linked List
 */
typedef struct  node_s {
	struct node_s* next;
	type value;	
} node_t;

// Insert node 
node_t* insert (node_t* head, node_t* new){
	new -> next = head;
	head = new;
	return head;
}

// *Reverse the linked list*
node_t* rev(node_t* head){
	node_t* h2 = NULL, *prev = NULL;
	while(head != NULL){
		prev = h2;
		h2 = head;
		head = head->next;
		h2->next = prev;
	}
	return h2;
}

// Append a node at the end
node_t * append(node_t* head, node_t*new){
	new->next = NULL;
	if (head == NULL){
		return new;
	}
	node_t* last = head;
	while (last->next != NULL){
		last = last->next;
	}
	last -> next = new;
	return head;
}