#include "globalstates.h"

State facState = Idle;
State primeState = Idle;
QMutex primeMX, facMX;

State getPrimeState()
{
    primeMX.lock();
    State state = primeState;
    primeMX.unlock();
    return state;
}

State getFacState()
{
    facMX.lock();
    State state = facState;
    facMX.unlock();
    return state;
}

void setPrimeState(State state)
{
    primeMX.lock();
    primeState = state;
    primeMX.unlock();
}

void setFacState(State state)
{
    facMX.lock();
    facState = state;
    facMX.unlock();
}
