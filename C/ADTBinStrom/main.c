#include <stdio.h>
#include "tree.h"
#include "ioutils.h"
#include <stdlib.h>

void inorder(TreeNode *uk);

void printMenu()
{
	printf( "1 - tree_init()\n"
			"2 - tree_clear()\n"
			"3 - tree_insert()\n"
			"4 - tree_delete()\n"
			"5 - tree_find_node()\n"
			"6 - tree_get_node_count()\n"
			"7 - tree_proces()\n"
			"M - zobraz toto menu\n"
			"K - konec\n"
			"Pro ukonceni stiskni CTRL+D (Linux) nebo CTRL+Z (Windows).\n"
			);
}

int main(int argc, char **argv)
{
    Tree myTree;
	//Tree_Init(&myTree);
	Data_t myData;
	char isTreeInitialized = 0;
	printf("Strom\n----------\n\n");
	char volba;
    
	printMenu();
    
	while (1) {
	switch (volba = io_utils_get_char_line())
	{
		printf("Vase volba=%c\n",volba);
		case '1':
		if(Tree_Init(&myTree)){
            printf("Strom je inicializovan!\n");
            isTreeInitialized = 1;
            }
		
		break;
		case '2':
        if(isTreeInitialized)
			{
                printf("Obsah stromu byl odstranen.\n");
                Tree_Clear(&myTree);
            }
		break;
		case '3':
        if(isTreeInitialized)
			{
                printf("Data uzlu stromu:\n");
                Tree_Process(&myTree, (TreeNodeProc)Tree_Get_Data,3);
                Data_Get(&myData);
                Tree_Insert(&myTree, myData);
            }
		break;
		case '4':
        if(isTreeInitialized)
			{
                printf("Zadej mazana data:\n");
                Data_Get_Simple(&myData);
                Tree_Delete(&myTree, myData);
                printf("Data smazana\n");
            }
		break;
		case '5':
        if(isTreeInitialized)
			{
                printf("Zadej hledana data:\n");
                Data_Get_Simple(&myData);
                if(Tree_Find_Node(myTree, myData)!=NULL)
                {
                    printf("Data byla nalezena v uzlu na adrese %p\n",Tree_Find_Node(myTree, myData));
                }
                else
                    {
                        printf("Data nebyla ve strome nalezena.\n");
                    }
            }
		break;
		case '6':
        if(isTreeInitialized)
			{
                printf("Pocet uzlu stromu: %d\n",(int) Tree_Get_Count(myTree));
            }
		break;
		case '7':
		if(isTreeInitialized)
			{
				printf("Pruchod:\n1 - preorder\n2 - inorder\n3 - postorder\n\n");
				volba = io_utils_get_char_line();
				printf("Vase volba %c:\n" ,volba);
				if(volba=='1' || volba=='2' || volba=='3')
					{
						Tree_Process(&myTree, (TreeNodeProc)Tree_Get_Data, atoi(&volba));
					}
				else
					{
						printf("Neznama volba!\n");
					}
				
			}
		else
			{
				printf("Strom neni inicializovan!\n");
			}
		break;
		case 'M':
		printMenu();
		break;
		case 'K':
		return 0;
		default:
		break;
	}
	}
	return 0;
}
