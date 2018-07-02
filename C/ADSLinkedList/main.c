#include <stdio.h>
#include "list.h"
#include "ioutils.h"

void printMenu()
{
	printf("Zadejte pismeno 0-A pro jednu z nasledujicich cinnosti:\n");
	printf( "0: Init,\n"
			"1: Actualize,\n"
			"2: Insert_First,\n"
			"3: First,\n"
			"4: Copy_First,\n"
			"5: Delete_First,\n"
			"6: Post_Delete,\n"
			"7: Post_Insert,\n"
			"8: Copy,\n"
			"9: Succ,\n"
			"A: Is_Active,\n"
			"M: Vypis menu\n"
			"CTRL+Z (Win) nebo CTRL+D (Unix): Konec programu\n"
			);
}

void tiskni_seznam(List_t seznam1){
    Data_t data;
    List_First(&seznam1);
    while(List_Copy(seznam1, &data)){
        Data_Print(&data);
        List_Succ(&seznam1);
        
        }
    }

int main(int argc, char **argv)
{
    //pokusna data
    Data_t data;
    List_t seznam1;
    List_Init(&seznam1);
    char volba;
    
    printMenu();
    while (1) {
	switch (volba = io_utils_get_char_line()) 
	{
		printf("Vase volba=%c\n",volba);
		case '0':
		List_Init(&seznam1);
		break;
		case '1':
		Data_Get(&data);
		List_Actualize(&seznam1,data);
		break;
		case '2':
		printf("Insert_First - vlozeni nove polozky na 1. misto seznamu\n");
		Data_Get(&data);
		List_Insert_First(&seznam1,data);
		break;
		case '3':
		printf("First - nastaveni aktivni polozky na 1.prvek\n");
		List_First(&seznam1);
		break;
		case '4':
		printf("Copy_First - Vypis 1.prvku seznamu");
		List_Copy_First(seznam1,&data);
		break;
		case '5':
		printf("Delete_First - vymaz 1.prvek\n");
		List_Delete_First(&seznam1);
		break;
		case '6':
		printf("Post_Delete - vymaz prvek za aktivnim prvkem\n");
		List_Post_Delete(&seznam1);
		break;
		case '7':
		printf("Post_Insert - vloz novy prvek za aktivni prvek\n");
		Data_Get(&data);
		List_Post_Insert(&seznam1,data);
		break;
		case '8':
		printf("Copy - ziskani hodnoty aktivniho prvku\n");
		List_Copy(seznam1,&data);
		Data_Print(&data);
		break;
		case '9':
		printf("Succ - posuv ukazatel aktivniho prvku na dalsi prvek\n");
		List_Succ(&seznam1);
		break;
		case 'A':
		printf("Is_Active - zjisteni, zda je seznam aktivni\n");
		printf("Is_Active=");
		printf("%s\n", List_Is_Active(seznam1) ? "true" : "false");
		break;
		case 'M':
		printMenu();
		break;
		default:
		break;
	}
	if(volba != 'M')List_Print_Status(&seznam1);
	}
	return 0;
    
}
