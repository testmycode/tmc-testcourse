//SOLUTION FILE
package ilmoitin;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.JLabel;
import javax.swing.JTextField;

public class MyActionListener implements ActionListener {

    private JTextField inputField;
    private JLabel outputField;

    MyActionListener(JTextField inputField, JLabel outputField) {
        this.inputField = inputField;
        this.outputField = outputField;
    }

    @Override
    public void actionPerformed(ActionEvent ae) {
        outputField.setText(inputField.getText());
        inputField.setText("");
    }
}
