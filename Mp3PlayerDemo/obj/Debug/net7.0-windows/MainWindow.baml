   M S B A M L   `   `   `  ����H  DMp3PlayerDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Mp3PlayerDemoMp3PlayerDemo  5   	       Mp3PlayerDemo.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Mp3PlayerDemo     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    J� CommandBindings 5
      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ MediaCommands.Play��5      66     5   
   -   5        $ MediaCommands.Pause��5      67     5   
   -   5        $ MediaCommands.Stop��5      66   .��5      ]� $
��True��6   .+�5   
   o� $	��Top=�6   .@�5      m� $��_File��6   .@�5      m� -   5        $��_Open��5      6*   m� 5      -   5        $��_Exit��5      6*   5      m� 5      $��_Edit��6   .@�5      m� -   5        $��Edit _Title��5      60   m� 5      -   5        $��Edit _Album��5      60   m� 5      -   5        $��
Edit _Year��5      6/   5      m� 5      $��_Media��6   .@�5      m� $��_Play��6    m� Command$ MediaCommands.Play��6*   m� 5      $��_Pause��6   $ MediaCommands.Pause��6+   m� 5      $��_Stop��6   $ MediaCommands.Stop��6*   5      5       �� 5!   
   $
��Left=�6    �� Orientation$ Vertical=�6+   $	��100��6B   $��10,5,0,0q�6N   .+�5"      �� -	   5        $��50��5"      $��50��6    ��5#      �� 5$      $��images/media-play.png��6   5&      �� 5(      -
   5        $��50��5(      $��50��6     � ToolTip$ Pause��6@   ��5)      �� 5*      $��Images/pause-icon.png��6   5,      �� 5.      -   5        $��50��5.      $��50��6    $
 Stop��6?   ��5/      �� 50      $��Images/stop-icon.png��6   52      53      � 56   
   $	��Top=�6   $��0,5,0,0q�6$   .+�58      �� $��images/backgroundOne.png��6   $
��Fill=�66    J� Opacity$	 0.5Q�6E   �� 5:      
���   �$	 0.5Q�6%   �� 5<      $	��245��6   .+�5=      r� -   5         r�Name$ myMediaPlayer��5=       r� LoadedBehavior$ Manual=�66   	 r� UnloadedBehavior$	 Manual=�6N      Mp3PlayerDemo.NowPlaying  5>      -   5        
  Name$
 nowPlayingControl��5>   #   $	��100��6>   5?      5@      5A      5B      