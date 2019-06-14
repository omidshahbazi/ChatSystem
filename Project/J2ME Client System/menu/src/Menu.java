/*
 * menu.java
 *
 * Created on December 21, 2009, 4:14 PM
 *
 * To change this template, choose Tools | Options and locate the template under
 * the Source Creation and Management node. Right-click the template and choose
 * Open. You can then make changes to the template in the Source Editor.
 */

/**
 *
 * @author TMOC 1
 */
import javax.microedition.lcdui.*;
import javax.microedition.lcdui.game.*;

public class Menu
{
    private String leftOption; 
    private String rightOption;
    private String cancelOption = "Cancel"; 
    private String[] menuOptions;   
    private int padding = 5;
    
    /** Creates a new instance of menu */
    public Menu(String leftOption, String rightOption, String[] menuOptions)  { 
    this.leftOption = leftOption;
    this.rightOption = rightOption;
    this.menuOptions = menuOptions;     
    }  
    public void drawInactiveMenu(GameCanvas canvas, Graphics g) { 
    Font font = Font.getFont(Font.FACE_SYSTEM, Font.STYLE_BOLD, Font.SIZE_MEDIUM);
    int fontHeight = font.getHeight();
    int width = canvas.getWidth();
    int height = canvas.getHeight();
    g.setColor(0xcccccc); 
    g.fillRect(0, height - fontHeight - 2 * padding, width, height);
    g.setFont(font);
    g.setColor(0x000000); 
    g.drawString(leftOption, padding, height - padding, g.LEFT | g.BOTTOM);
    g.drawString(rightOption, width - padding, height - padding, g.RIGHT | g.BOTTOM); 
    canvas.flushGraphics();     }
     public void drawActiveMenu(GameCanvas canvas, Graphics g, int selectedOptionIndex) {   
     Font font = Font.getFont(Font.FACE_SYSTEM, Font.STYLE_BOLD, Font.SIZE_MEDIUM);
     int fontHeight = font.getHeight();
     int width = canvas.getWidth();
     int height = canvas.getHeight();
     g.setColor(0xcccccc); 
     g.fillRect(0, height - fontHeight - 2 * padding, width, height);
     g.setFont(font);
     g.setColor(0x000000); 
     g.drawString(cancelOption, width - padding, height - padding, g.RIGHT | g.BOTTOM);
     canvas.flushGraphics();
     if (menuOptions != null) { 
         }           
     int menuMaxWidth = 0;
     int menuMaxHeight = 0;
     int currentWidth = 0;
    }
    for (int i = 0; i < menuOptions.length; i++) { 
     currentWidth = font.stringWidth(menuOptions[i]); 
     if (currentWidth > menuMaxWidth) { 
         menuMaxWidth = currentWidth; 
     }                 menuMaxHeight += fontHeight + padding;
            menuMaxWidth += 2 * padding; 
            g.setColor(0xcccccc);          
            g.fillRect(0,  height - fontHeight - 2 * padding - menuMaxHeight,  menuMaxWidth,  menuMaxHeight);
            g.setFont(font);
            int menuOptionX = padding;
            int menuOptionY = height - fontHeight - 2 * padding - menuMaxHeight + padding;
            for (int i = 0; i < menuOptions.length; i++) { 
                if (i != selectedOptionIndex) {  
                    g.setColor(0x000000);      }              
                else { 
                    g.setColor(0x0000ff);                 } 
                g.drawString(menuOptions[i], menuOptionX, menuOptionY, g.LEFT | g.TOP); 
                menuOptionY += padding + fontHeight;             } 
            canvas.flushGraphics();         } 
} 
            }
     }
    }
}
