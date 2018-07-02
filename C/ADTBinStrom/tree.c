#include "tree.h"
#include <stdlib.h>
#include <stdio.h>

////////////////////////////////////////////////////////////////////////////////
// operace nad stromem
// Na prednasce receno ze neni treba vyvazovat
// podivat se na algorytmus vypoctu vysky stromu
// priklad v semestralce ..zijstit patro s nejvetsi sirkou
// hash tabulka jako premie!!! 
/*!
 * \brief Provede inicializaci stromu před jeho použitím.
 * \param root Ukazatel na inicializovaný strom
 */
bool Tree_Init( Tree * const root ){
    root->root = NULL;
    root->itemsCount = 0;
    return true;    
}

/*!
 * \brief Odstraní všechny listy stromu.
 * \param root Ukazatel na strom
 */
void Tree_Clear( Tree* const root )
{
    Tree_Process(root,(TreeNodeProc)free,3);
    root->root = NULL;
    root->itemsCount = 0;
}

/*!
 * \brief Vytvoří uzel s daty a vloží ho do stromu na správnou pozici.
 * \param root Ukazatel na strom, kam má být nový uzel vložen
 * \param data Ukazatel na data stromu
 * \return Fce vrátí hodnotu TRUE proběhla-li operace úspěšně. V případě, že se nepodařilo vytvořit
 * nový uzel, nebo strom ji obsahuje uzel se stejnými daty, bude vrácena hondota FALSE.
 */
bool Tree_Insert( Tree* const root, const Data_t data ){
        TreeNode * uk = root->root, * prev = NULL;
        
        int cmp;
        while(uk != NULL){
                cmp = Data_Cmp(&uk->data,&data);
                prev = uk;
                if(cmp == 0) return false;
                else if (cmp < 0) uk = uk->right;
                else uk = uk->left;
            }
            
        uk = malloc(sizeof(TreeNode));
        if(uk == NULL){
            fprintf(stderr,"Tree_Insert: malloc error\n");
            return false;
            }
        uk->data = data;
        uk->left = uk->right = NULL;
        if(prev!= NULL){
            if(cmp < 0) prev->right = uk;
            else prev->left = uk;
            
        } else {
            root->root = uk;                
        }
        root->itemsCount += 1;
        return true;
    
    }

/*!
 * \brief Smaže uzel ze stromu obsahující data o dané hodnotě dle příslušných pravidel (viz. přednáška) včetně jeho dat, je-li příznak stromu "deleteContents" roven TRUE.
 * \param root Ukazatel na strom, odkud má být uzel smazán
 * \param data Ukazatel na data obsažená v mazaném uzlů (může se jednat o jinou instanci Data_tu; důležité je pouze hodnota)
 */
void Tree_Delete( Tree* const root, const Data_t data )
{
	bool found = false;
    int delType = 0;
    int cmp;

    int stranaPredchoziho = 0;
    TreeNode* node = root->root;
    TreeNode* prevNode;
	TreeNode* nodeChild;
	TreeNode* toBeDeletedNode;
	TreeNode* prevDelNode;

    while(node != NULL && found != true) 
	{

		cmp = Data_Cmp(&data,&node->data);
        if(cmp < 0) cmp = 1;
        else if (cmp > 0) cmp = 2;
        else  if (cmp == 0) cmp = 3;
		switch(cmp) 
		{
		case 1:
			prevNode = node;
			node = node->left;
			break;
		case 2:
			prevNode = node;
			node = node->right;
			break;
		case 3:
			found = true;
			break;
		}
	}
	if(node == NULL || found == false)
		{
			printf("Uzel nebyl nalezen, nic nebylo smazano.\n");
			return;
		}
	
    /* Možnost různých situací
     * delType = 1 - mazany prvek neni koren a nema zadne potomky
     * delType = 2 - mazany prvek neni koren a ma jednoho potomka (vnouce dedovi)
     * delType = 3 - mazany prvek neni koren a ma oba potomky
	 * delType = 4 - mazany prvek je koren a nema zadne potomky
	 * delType = 5 - mazany prvek je koren a ma jednoho potomka
	 * delType = 6 - mazany prvek je koren a ma oba potomky
     */
	 //Neni koren
	if(node != root->root)
	{
		//Ziskani strany kde lezi mazany prvek
		if(node == prevNode->left) {
		stranaPredchoziho = 1;
	    } else if(node == prevNode ->right){
		stranaPredchoziho = 2;
	    }
		//Určení druhu mazání
		delType = (node->left == NULL && node->right == NULL) * 1 +
		             ((node->left == NULL && node->right != NULL) ||
		              (node->left != NULL && node->right == NULL)) * 2 +
		             (node->left != NULL && node->right != NULL) * 3;
	}
	//Je koren
	else
		{
			delType = (node->left == NULL && node->right == NULL) *4 +
			((node->left == NULL && node->right != NULL) ||
		              (node->left != NULL && node->right == NULL)) *5 +
			(node->left != NULL && node->right != NULL) * 6;
		}
    switch(delType) {
    case 1:
	//mazany prvek neni koren a nema zadne potomky
	if(stranaPredchoziho == 1) {
	    prevNode->left = NULL;
	} else if(stranaPredchoziho==2){
	    prevNode->right = NULL;
	}
	free(node);
    root->itemsCount -= 1;
	break;
    case 2:
	//mazany prvek neni koren a ma jednoho potomka
	//Nalezeni strany potomka
	if(node->left!=NULL)
		nodeChild = node->left;
	else
		{
			nodeChild = node->right;
		}
	//Přesměrování, aby predchozí uzel ukazoval na potomka
	if(stranaPredchoziho == 1)
		{
			prevNode->left = nodeChild;
		}
	else
		{
			prevNode->right = nodeChild;
		}
	free(node);
    root->itemsCount -= 1;
	break;
    case 3:
	//mazany prvek neni koren a ma oba potomky
	//Ulozeni adres aktualniho a predchoziho uzlu
	prevDelNode = prevNode;
	toBeDeletedNode = node;
	node = node->left;
	//Nalezeni uzlu pro nahrazeni
	while(node->right!=NULL)
		{
			prevNode = node;
			node = node->right;
		}
	node -> left = toBeDeletedNode->left;
	node -> right = toBeDeletedNode->right;
	if(stranaPredchoziho == 1)
		{
			prevDelNode->left = node;
		}
	if(stranaPredchoziho == 2)
		{
			prevDelNode->right = node;
		}
	prevNode->right = NULL;
	free(toBeDeletedNode);
    root->itemsCount -= 1;
	break;
	case 4:
	//mazany prvek je koren a nema zadne potomky
	free(node);
	root->root = NULL;
    root->itemsCount -= 1;
	break;
	case 5:
	//Nalezeni strany potomka
	if(node->left!=NULL)
		nodeChild = node->left;
	else
		{
			nodeChild = node->right;
		}
	free(node);
	root->root = nodeChild;
    root->itemsCount -= 1;
	break;
	case 6:
	//mazany prvek je koren a ma oba potomky
	//Ulozeni adres aktualniho a predchoziho uzlu
	prevDelNode = prevNode;
	toBeDeletedNode = node;
	node = node->left;
	//Nalezeni uzlu pro nahrazeni
	while(node->right!=NULL)
		{
			prevNode = node;
			node = node->right;
		}
	node->left = toBeDeletedNode->left;
	node->right = toBeDeletedNode->right;
	root->root=node;
	free(toBeDeletedNode);
    root->itemsCount -= 1;
	break;
    }
}

/*!
 * \brief Vrátí data uzlu.
 * \param node Ukazatel na data
 * \return Ukazatel na data uložená v uzlu
 */
Data_t *Tree_Get_Data( TreeNode* node )
{
    if(node!=NULL){
        
		Data_Print(&node->data);
		return &node->data;
        
    }else{
        
		return NULL;
        
	}
}

/*!
 * \brief Vrátí ukazatel na uzel, který drží daná data.
 * \param root Ukazatel na strom, ve kterém má být uzel vyhledán
 * \param data Ukazatel na data, která budou hledána
 * \return Fce vrátí ukazatel na uzel držící hledaná data pokud existuje, jinak vrátí NULL
 */
TreeNode* Tree_Find_Node( Tree root, const Data_t data )
{
    TreeNode* node = root.root;
    int cmp;
    while(node != NULL) {
	cmp = Data_Cmp(&data, &node->data);
	//cmp = (cmp < 0) * (1) + (cmp > 0) * 2 + (cmp == 0) * 3;
    if(cmp < 0) cmp = 1;
    else if (cmp > 0) cmp = 2;
    else  if (cmp == 0) cmp = 3;
	switch(cmp) {
	case 1:
	    node = node->left;
	    break;
	case 2:
	    node = node->right;
	    break;
	case 3:
	    return node;
	    break;
        }
    }
    return NULL;
}

/*!
 * \brief Spočítá všechny uzly stromu.
 * \param root Ukazatel na strom
 * \return Fce vrátí počet uzlů stromu
 */
size_t Tree_Get_Count( Tree root )
{
    return root.itemsCount;
}

/*void inorder(TreeNode * uk){
    if(uk!= NULL){
        inorder(uk->left);
        Data_Print(&uk->data);
        inorder(uk->right);
        
        }
}*/
/*!
 * \brief Zpracuje každý uzel stromu pomocí funkce specifikované ukazatelem "proc". Průchod stromem
 * může být trojí: PREORDER, INORDER a POSTORDER.
 * \param root Ukazatel na strom jehož uzly mají být zpracovány
 * \param proc Ukazatel na callback funkci pro zpracování uzlu
 * \param mode Typ průchodu stromem (viz. výčtový typ TreeProcessMode)
 * \sa TreeProcessMode
 */
void Tree_Process( Tree *root, TreeNodeProc proc, TreeProcessMode mode )
{
    if(root->root != NULL) Process_TreeNodes(root->root, (TreeNodeProc)proc, mode);
}

void Process_TreeNodes( TreeNode *node, TreeNodeProc proc, TreeProcessMode mode )
{
    if(node != NULL) {
	switch(mode) {		
	case 1:
	    proc(node);
	    Process_TreeNodes(node->left, (TreeNodeProc)proc, 1);
	    Process_TreeNodes(node->right, (TreeNodeProc)proc, 1);
	    break;
	case 2:
	    Process_TreeNodes(node->left, (TreeNodeProc)proc, 2);
	    proc(node);
	    Process_TreeNodes(node->right, (TreeNodeProc)proc, 2);
	    break;
	case 3:
	    Process_TreeNodes(node->left, (TreeNodeProc)proc, 3);
	    Process_TreeNodes(node->right, (TreeNodeProc)proc, 3);
	    proc(node);
	    break;
        }
    }
}
