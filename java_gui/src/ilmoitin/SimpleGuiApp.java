package ilmoitin;

import java.awt.Container;
import java.awt.Dimension;
import java.awt.GridLayout;
import javax.swing.*;

public class SimpleGuiApp implements Runnable {

    private JFrame frame;

    @Override
    public void run() {
        //BEGIN SOLUTION
        frame = new JFrame("Frame");
        frame.setPreferredSize(new Dimension(400, 200));

        frame.setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);

        createComponents(frame.getContentPane());

        frame.pack();
        frame.setVisible(true);
        //END SOLUTION
    }

    private void createComponents(Container container) {
        //BEGIN SOLUTION
        JLabel outputField = new JLabel();
        JTextField inputField = new JTextField();
        JButton refresh = new JButton("Refresh");

        refresh.addActionListener(new MyActionListener(inputField, outputField));
        container.setLayout(new GridLayout(3, 1));

        container.add(inputField);
        container.add(refresh);
        container.add(outputField);
        //END SOLUTION
    }
}
