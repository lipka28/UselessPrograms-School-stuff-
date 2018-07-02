#include "vector.h"
#include "stdlib.h"

/* Public Vector API */
/**
 * @brief   Vytvoří vektor s počáteční velikostí speicifikovanou parametrem
 * @param   initial_size    počáteční velikost Vectoru
 * @param   alloc_step      Určuje, po jak velkých blocích se přialokovává paměť
 * @return  Vrací nově alokovanou strukturu popisující Vector jinak NULL pokud dojde k problémům.
 */
Vector_t *Vector_Create( uint64_t initial_size, uint32_t alloc_step )
{
    Vector_t v;
    v.items = malloc(initial_size * sizeof(uint64_t));
    if(v.items == NULL) return NULL;
    v.size = v.free_cells = initial_size;
    v.alloc_step = alloc_step;
    Vector_t *uk = malloc(sizeof(Vector_t));
    if(uk == NULL) {
        free(v.items);
        return NULL;
    }
    *uk = v;
    return uk;
}

/**
 * @brief   Vytvoří samostatnou kopii vektoru
 * @param   original    Ukazatel na kopírovaný Vector
 * @return  Vrací strukturu popisující zkopírovaný Vector. Při chybách vrátí NULL
 */
Vector_t *Vector_Copy( const Vector_t *original )
{
    Vector_t v;
    v.items = malloc(original->size * sizeof(uint64_t));
    if(v.items == NULL) return NULL;
    for(int i =0; i< v.size-v.free_cells;i++){
        v.items[i] = original->items[i];
        }
    v.free_cells = original->free_cells;
    v.alloc_step = original->alloc_step;
    v.size = original->size;
    
    Vector_t *uk = malloc(sizeof(Vector_t));
    if(uk == NULL) {
        free(v.items);
        return NULL;
    }
    *uk = v;
    return uk;
//memcpy
}

/**
 * @brief   Vymaže obsah vektoru, uvolní paměť a nastaví jeho velikost na 0. Prvek alloc_step zůstává nezměněn.
 * @param   vector  Ukazatel na Vector
 */
void Vector_Clear( Vector_t *vector ) 
{
    free(vector->items);
    vector->free_cells = 0;
    vector->size = 0;
}

/**
 * @brief   Vrací aktuální délku vektoru
 * @param   vector  Ukazatel na Vector
 * @return  Aktuální délka vektoru nebo UINT64_MAX pokud je předán NULL
 */
uint64_t Vector_Length( Vector_t *vector ) 
{
    return vector->size - vector->free_cells;
}

/**
 * @brief   Navrací hodnotu vektoru na vybraném umístění
 * @param   vector      Ukazatel na Vector
 * @param   position    Pozice v rámci Vectoru
 * @param   value       Ukazatel pro navrácení hodnoty pokud byla nalezena
 * @return  Vrací true pokud je prvek ve vektoru jinak false
 */
bool Vector_At( Vector_t *vector, uint64_t position, uint64_t *value ) 
{
    if(position >= vector->size - vector->free_cells)
    {
        value = 0;
        return false;
    }
    else
    {
        *value = vector->items[position];
        return true;
    }
    
}

/**
 * @brief   Odstraní prvek na vybrané pozici a posune data o prvek doleva.
 * @param   vector      Ukazatel na Vector
 * @param   position    Pozice v rámci Vectoru
 * @return  Vrací true pokud byla pozice uvnitř rozsahu jinak false
 */
bool Vector_Remove( Vector_t *vector, uint64_t position )
{
    if(position < Vector_Length(vector)){
        if(position == Vector_Length(vector)-1) {
			vector->items[position] = 0;
			vector->free_cells++;
		} else {
			for(int i = position +1; i<Vector_Length(vector); i++) {
				vector->items[i-1] = vector->items[i];
			}
			vector->free_cells++;
		}
		return true;
    }
    else return false;

}

void Vector_Append( Vector_t *vector, uint64_t value )
{
    if(vector->free_cells <= 0) {
        void *uk = realloc(vector->items,(vector->size+vector->alloc_step) * sizeof(uint64_t));
        if(uk == NULL) return;
        else {
            vector->items = uk;
            vector->size += vector->alloc_step;
            vector->free_cells = vector->alloc_step;
        }
    }

    int firstFree = vector->size - vector->free_cells;
    vector->items[firstFree] = value;
    vector->free_cells--;

}

/**
 * @brief   Funkce slouží k zjištění, jestli se někde ve vektoru nachází daná hodnota
 * @param   vector  Ukazatel na Vector
 * @param   value   Hledaná hodnota
 * @return  Vrací true pokud je hodnota nalezena, jinak false
 */
bool Vector_Contains( Vector_t *vector, uint64_t value ) 
{
    for(int i = 0; i < Vector_Length(vector); i++){
        if(vector->items[i] == value) return true;
        }
    return false;
}

/**
 * @brief   Hledá pozici prvku s danou hodnotou ve Vectoru
 * @param   vector  Ukazatel na Vector
 * @param   value   Hledaná hodnota
 * @param   from    Pozice od které se začíná hledat
 * @return  Vrací pozici prvku pokud je nalezen, jinak -1
 */
int64_t Vector_IndexOf( Vector_t *vector, uint64_t value, uint64_t from ) 
{
    int64_t index;
    bool found = false;
    if(from > Vector_Length(vector) && from >= 0){
        index = -1;
        } else {
            for(int i = from; i < Vector_Length(vector) && found == false; i++){
                if(vector->items[i] == value){
                    index = i;
                    found = true;
                    }
                }
            }
    if(found == false) index = -1;
    
    return index;
    
}

/**
 * @brief   Vyplní část vektoru zadanou rozsahem nějakou hodnotou. Vektor je přepsán od začáteční pozice až po koncovou (včetně).
 * Pokud je koncová pozice za rozsahem vektoru, je vyplněna část od počáteční pozice po poslení prvek vektoru. Jestli je počáteční pozice za koncem vektoru,
 * není vykonáno nic.
 * #note    Bonusová funkce pro aktivní studenty
 * @param   vector          Ukazatel na Vector
 * @param   value           Nastavovaná hodnota
 * @param   start_position  Počáteční pozice
 * @param   end_position    Konečná pozice
 */
void Vector_Fill( Vector_t *vector, uint64_t value, uint64_t start_position, uint64_t end_position ) 
{
    if(start_position < end_position && start_position >= 0 && end_position < Vector_Length(vector)) {
		for(int i = start_position; i<end_position; i++) {
			vector->items[i] = value;
		}
	}
    
}
