#include <stdio.h>


typedef enum {START, MOZNA_POZNAMKA, JEDNORADKOVA, VICERADKOVA, MOZNA_KONEC, RETEZEC, BACKSLASH, ZNAK} tStavy;
int main(int argc, char **argv)
{
    FILE *vstup;
    FILE *vystup;
    tStavy stav = START;
    tStavy lastStav = START;
    switch(argc) {
    case 1:
        vstup = stdin;
        vystup = stdout;
        break;
    case 2:
        vstup = fopen(argv[1],"r");
        vystup = stdout;

        break;
    case 3:
        vstup = fopen(argv[1],"r");
        vystup = fopen(argv[2],"w");

        break;
    default:
        vstup = stdin;
        vystup = stdout;
        break;

    }

    char znak;

    while((znak = fgetc(vstup)) != EOF) {
        switch (stav) {

        case START:
            if(znak =='/') stav = MOZNA_POZNAMKA;
            else if(znak == '"') {
                stav = RETEZEC;
                lastStav = START;
                fputc(znak,vystup);
            } else if(znak == '\'') {
                stav = ZNAK;
                lastStav = START;
                fputc(znak,vystup);
            } else {
                fputc(znak,vystup);
                lastStav = START;
            }
            break;
        case MOZNA_POZNAMKA:
            if(znak =='/') {
                stav = JEDNORADKOVA;
                lastStav = MOZNA_POZNAMKA;
            } else if(znak == '*') {
                stav = VICERADKOVA;
                lastStav = MOZNA_POZNAMKA;
            } else {
                fputc('/',vystup);
                fputc(znak,vystup);
                stav = START;
                lastStav = MOZNA_POZNAMKA;
            }
            break;
        case JEDNORADKOVA:
            if(znak == '\n') {
                fputc('\n',vystup);
                stav = START;
                lastStav = JEDNORADKOVA;
            }
            break;
        case VICERADKOVA:
            if(znak == '*') {
                stav = MOZNA_KONEC;
                lastStav = VICERADKOVA;
            }
            break;
        case MOZNA_KONEC:
            if(znak == '/') {
                stav = START;
                lastStav = MOZNA_KONEC;
            } else {
                stav = VICERADKOVA;
                lastStav = MOZNA_KONEC;
            }
            break;
        case RETEZEC:
            if(znak == '\\') {
                stav = BACKSLASH;
                lastStav = RETEZEC;
                fputc(znak,vystup);
            } else if (znak == '"') {
                stav = START;
                lastStav = RETEZEC;
                fputc(znak,vystup);
            } else {
                fputc(znak,vystup);
                lastStav = RETEZEC;
            }
            break;
        case BACKSLASH:
            fputc(znak,vystup);
            stav = lastStav;
            lastStav = BACKSLASH;
            break;
        case ZNAK:
            if(znak == '\'') {
                stav = START;
                lastStav = ZNAK;
                fputc(znak,vystup);
            } else if(znak == '\\') {
                fputc(znak,vystup);
                lastStav = ZNAK;
                stav = BACKSLASH;
            } else {
                fputc(znak,vystup);
                lastStav = ZNAK;
            }
            break;

        }

    }

    fclose(vstup);
    fclose(vystup);

    return 0;
}
