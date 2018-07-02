#ifndef FACWORKER_H
#define FACWORKER_H

#include <QObject>
#include <QThread>
#include "globalstates.h"

class FacWorker : public QObject
{
    Q_OBJECT
public:
    explicit FacWorker(QObject *parent = nullptr);

private:
    unsigned long long countFac(int num);

signals:
    void resultsReady(unsigned long long result);

public slots:
    void doWrok(int target);
};

#endif // FACWORKER_H
