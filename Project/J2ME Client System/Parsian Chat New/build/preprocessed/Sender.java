
import java.io.*;


public class Sender extends Thread {

    private OutputStream os;
    private String message;

    public Sender(OutputStream os) {
        this.os = os;
//        start();
        Thread tr = new Thread(this);
        tr.start();
    }

    public synchronized void Send(String msg) {
        message = msg;
        notify();
    }

    public void run() {
        while (true) {
            // If no client to deal, wait until one connects
            if (message == null) {
                try {
                    wait();
                } catch (InterruptedException e) {
                }
            }

            if (message == null) {
                break;
            }

            try {
                os.write(message.getBytes());
                os.flush();
            } catch (IOException ioe) {
                ioe.printStackTrace();
            }

            // Completed client handling, return handler to pool and
            // mark for wait
            message = null;
        }
    }

    public synchronized void Stop() {
        message = null;
        notify();
    }
}
