#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>
#include <QObject>
#include <QTimer>
#include "pi.h"

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();

private slots:
    void on_pushButton_clicked();

    void on_actionStart_timer_triggered();

private:
    Ui::MainWindow *ui;
    Pi *myPi;
    QTimer *timer;
    bool checked;
};

#endif // MAINWINDOW_H
