#ifndef _TREE_H_
#define _TREE_H_

#include "data.h"
#include <stdbool.h>
#include <stdio.h>

////////////////////////////////////////////////////////////////////////////////
// definice datových struktur

/*!
 * \brief Datová struktura listu stromu.
 */
typedef struct _TreeNode {
    Data_t  data;				/**< Data listu stromu */
    struct _TreeNode * left;	/**< Ukazatel na levý list stromu */
    struct _TreeNode * right;	/**< Ukazatel na pravý list stromu */
} TreeNode;

/*!
 * \brief Datová struktura stromu.
 */
typedef struct _Tree {
    TreeNode * root;
    unsigned int itemsCount;
} Tree;

/*!
 * \brief Způsob průchodu stromem.
 */
typedef enum _TreeProcessMode {
    procPREORDER = 1,		/**< Data uzlu jsou zpracována před oběma jeho listy (= uzly budou zpracovány od kořene k listům) */
    procINORDER = 2,		/**< Nejprve zpracuj levý list, poté data a poté pravý list (= uzly budou zpracovány v seřazeném pořadí) */
    procPOSTORDER = 3		/**< Data uzlu jsou zpracována až po obou jeho listech (= uzly budou zpracovány od listů ke kořeni) */
} TreeProcessMode;

/*!
 * \brief Callback funkce pro zpracování uzlu při průchodu stromem.
 * \param Ukazatel na zpracovávaný uzel
 */
typedef void ( *TreeNodeProc )( TreeNode* node );

////////////////////////////////////////////////////////////////////////////////
// operace nad stromem

/*!
 * \brief Provede inicializaci stromu před jeho použitím.
 * \param root Ukazatel na inicializovaný strom
 */
bool Tree_Init( Tree * const root );

/*!
 * \brief Odstraní všechny listy stromu.
 * \param root Ukazatel na strom
 */
void Tree_Clear( Tree* const root );

/*!
 * \brief Vytvoří uzel s daty a vloží ho do stromu na správnou pozici.
 * \param root Ukazatel na strom, kam má být nový uzel vložen
 * \param data Ukazatel na data stromu
 * \return Fce vrátí hodnotu TRUE proběhla-li operace úspěšně. V případě, že se nepodařilo vytvořit
 * nový uzel, nebo strom ji obsahuje uzel se stejnými daty, bude vrácena hondota FALSE.
 */
bool Tree_Insert( Tree* const root, const Data_t data );

/*!
 * \brief Smaže uzel ze stromu obsahující data o dané hodnotě dle příslušných pravidel (viz. přednáška) včetně jeho dat, je-li příznak stromu "deleteContents" roven TRUE.
 * \param root Ukazatel na strom, odkud má být uzel smazán
 * \param data Ukazatel na data obsažená v mazaném uzlů (může se jednat o jinou instanci Data_tu; důležité je pouze hodnota)
 */
void Tree_Delete( Tree* const root, const Data_t data );

/*!
 * \brief Vrátí data uzlu.
 * \param node Ukazatel na data
 * \return Ukazatel na data uložená v uzlu
 */
Data_t *Tree_Get_Data( TreeNode* node );

/*!
 * \brief Vrátí ukazatel na uzel, který drží daná data.
 * \param root Ukazatel na strom, ve kterém má být uzel vyhledán
 * \param data Ukazatel na data, která budou hledána
 * \return Fce vrátí ukazatel na uzel držící hledaná data pokud existuje, jinak vrátí NULL
 */
TreeNode* Tree_Find_Node( Tree root, const Data_t data );

/*!
 * \brief Spočítá všechny uzly stromu.
 * \param root Ukazatel na strom
 * \return Fce vrátí počet uzlů stromu
 */
size_t Tree_Get_Count( Tree root );

/*!
 * \brief Zpracuje každý uzel stromu pomocí funkce specifikované ukazatelem "proc". Průchod stromem
 * může být trojí: PREORDER, INORDER a POSTORDER.
 * \param root Ukazatel na strom jehož uzly mají být zpracovány
 * \param proc Ukazatel na callback funkci pro zpracování uzlu
 * \param mode Typ průchodu stromem (viz. výčtový typ TreeProcessMode)
 * \sa TreeProcessMode
 */
void Tree_Process( Tree *root, TreeNodeProc proc, TreeProcessMode mode );

void Process_TreeNodes( TreeNode *node, TreeNodeProc proc, TreeProcessMode mode );

#endif //_TREE_H_
    