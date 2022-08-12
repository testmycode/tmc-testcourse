
import fi.helsinki.cs.tmc.edutestutils.Points;
import ilmoitin.Main;
import java.awt.Component;
import java.awt.Dimension;
import java.awt.GridLayout;
import java.awt.LayoutManager;
import javax.swing.AbstractButton;
import javax.swing.JButton;
import javax.swing.JFrame;
import org.fest.swing.finder.WindowFinder;
import org.fest.swing.fixture.FrameFixture;
import org.fest.swing.fixture.JLabelFixture;
import org.fest.swing.junit.testcase.FestSwingJUnitTestCase;
import org.fest.swing.launcher.ApplicationLauncher;
import org.junit.Test;
import junit.framework.Assert;
import org.fest.swing.core.ComponentMatcher;
import org.fest.swing.exception.ComponentLookupException;
import org.fest.swing.fixture.JButtonFixture;
import org.fest.swing.fixture.JTextComponentFixture;

@Points("java-gui")
public class SwingTest extends FestSwingJUnitTestCase {

    private FrameFixture frame;

    @Override
    protected void onSetUp() {
        try {
            ApplicationLauncher.application(Main.class).start();

            robot().settings().delayBetweenEvents(300);
            frame = WindowFinder.findFrame(JFrame.class).using(robot());
        } catch (Throwable t) {
            Assert.fail("Have you created JFrame" + t);
        }

        Dimension d = frame.component().getSize();
        Assert.assertTrue("Make the width at least 400 and heigth at least 200",
                d.height > 150 && d.width > 350);

    }

    @Test
    public void isLayout() {
        LayoutManager lm = ((JFrame) frame.component()).getContentPane().getLayout();

        Assert.assertTrue("Do you use GridLayout", lm instanceof GridLayout);

        GridLayout gl = (GridLayout) lm;

        Assert.assertEquals("Wrong amount of rows",
                3, gl.getRows());

        Assert.assertEquals("Wrong amout of columns",
                1, gl.getColumns());
    }

    @Test
    public void isButton() {
        confirm("Refresh", JButton.class);
        try {
            frame.label();
            frame.textBox();
        } catch (Throwable t) {
            Assert.fail("Do you have JLabel, JTextField and JButton.");
        }
    }

    @Test
    public void oneMessage() {
        tryOnce("test");
    }

    public void tryOnce(String expected) {
        JLabelFixture messageLabel = null;
        JTextComponentFixture syote = null;
        JButtonFixture paivita = null;
        String received = "";
        try {
            messageLabel = frame.label();
            syote = frame.textBox();
            paivita = frame.button();
        } catch (Throwable t) {
            Assert.fail("" + t);
        }
        try {
            syote.focus().setText(expected);
            paivita.focus().click();
            received = messageLabel.text();
            messageLabel.requireText(expected);
            syote.requireEmpty();
        } catch (Throwable t) {
            Assert.fail("" + t);
        }
    }

    static class M implements ComponentMatcher {

        public final String pattern;

        public M(String p) {
            pattern = p;
        }

        @Override
        public boolean matches(Component cmpnt) {
            if (!(cmpnt instanceof AbstractButton)) {
                return false;
            }
            AbstractButton ab = (AbstractButton) cmpnt;
            return ab.getText().matches(pattern);
        }

        @Override
        public String toString() {
            return "M{" + "pattern=" + pattern + '}';
        }
    }

    private  Component confirm(String text, Class type) {
        Component c = null;
        try {
            c = frame.robot.finder().find(new SwingTest.M("(?i).*" + text + ".*"));
        } catch (ComponentLookupException e) {
            Assert.fail("Coudln't find " + type.toString().replaceAll("class", "") + " component with text \"" + text + "\".\n\nDetails:\n" + e);
        }
        Assert.assertEquals("Component with text \"" + text + "\" is not of the proper type!",
                type,
                c.getClass());
        return c;
    }
}
