#ifndef GLOBALSTATES_H
#define GLOBALSTATES_H
#include <QMutex>

typedef enum {Idle,Working,Paused,Aborted} State;

extern QMutex primeMX, facMX;
extern State facState;
extern State primeState;

State getPrimeState();
State getFacState();
void setPrimeState(State state);
void setFacState(State state);


#endif // GLOBALSTATES_H
