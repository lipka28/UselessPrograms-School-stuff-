#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QMessageBox>
#include "globalstates.h"
#include "controller.h"

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();

private:
    Controller *core;

private:
    Ui::MainWindow *ui;

public slots:
    void handleFacResult(unsigned long long result);
    void handlePrimeResult(unsigned int result);
    void handlePrimeFinished();

private slots:
    void on_pb_facStart_clicked();
    void on_pb_primeStart_clicked();
    void on_pb_primePausRes_clicked();
    void on_pb_primeAbort_clicked();
    void on_pb_facPausRes_clicked();
    void on_pb_facAbort_clicked();
};

#endif // MAINWINDOW_H
