#include <stdio.h>
#include "vector.h"
#include "ioutils.h"
#include <stdint.h>
#include <inttypes.h>

int main(void)
{
    Vector_t * v = Vector_Create(10,10);
    long cislo;
	long index;
    uint64_t value;
    
    for(int i = 0; i < 100; i+=5){
        Vector_Append(v,i);
        }
    printf("Vector test program\n");
    while (1) {
		printf(
		    "Stisknete:\n"
		    "1 pro vypis delky vektoru\n"
		    "2 pro pridani prvku\n"
		    "3 pro odebrani prvku\n"
		    "4 pro vypis vsech prvku\n"
		    "5 pro zjisteni jestli vektor obsahuje prvek\n"
		    "6 pro nalezeni pozice prvku\n"
		    "7 pro vycisteni vektoru\n"
		    "cokoli jineho pro konec.\n"
			);
		switch (io_utils_get_char_line()) {
		case '1':
			//PRIu64 - pro vypisování 64bit int - include inttypes.h
			printf("Delka vektoru: %" PRId64 "\n", Vector_Length(v));
			break;
		case '2':
			printf("Vlozte hodnotu prvku:\n");
			io_utils_get_long(&cislo);
			Vector_Append(v,cislo);
			break;
		case '3':
			printf("Zadejte pozici prvku ktery chcete odebrat:\n");
			io_utils_get_long(&cislo);
			Vector_Remove(v, cislo);
			break;
		case '4':
			for(int i = 0; i< Vector_Length(v);i++)
				{
                    Vector_At(v,i,&value);
					printf("vector[%d]: %" PRIu64 "\n", i, value);
				}
			break;
		case '5':
			printf("Zadejte hodnotu hledaneho prvku:\n");
			io_utils_get_long(&cislo);
			if(Vector_Contains(v, cislo))
				{
					printf("Vector obsahuje prvek\n");
				}
			else
				{
					printf("Vector neobsahuje prvek\n");
				}
			break;
		case '6':
			printf("Zadejte hodnotu hledaneho prvku:\n");
			io_utils_get_long(&cislo);
			printf("Zadejte pocatecni index hledani:\n");
			io_utils_get_long(&index);
			printf("Pozice prvku: %" PRId64 "\n", Vector_IndexOf(v, cislo, index));
			break;
		case '7':
			Vector_Clear(v);
            v = Vector_Create(0,10);
			break;
		default:
			return 1;
			break;
		}
	};
	return 1;
}
