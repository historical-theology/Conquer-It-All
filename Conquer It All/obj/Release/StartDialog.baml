   M S B A M L   `   `   `  ����   Conquer It All     Conquer_It_All.StartDialog   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     Z VWPFToolkit.Extended, Version=1.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  $	��500��$	��500��
�������  � WindowStartupLocation$  CenterOwner=� � 
ResizeMode$ NoResize=� � WindowStyle$ 
ToolWindow=�.��� .+��� -    ��Name$ StartDialogStackPanel��$��10q� �� Orientation$ Vertical=����� *Width+ �� ElementName$ border������ *Height+$ border��.+�� -    �Name$ StartGameGrid��$	��100��$��0,0,0,10q�.+��� -    ��Name$ StartGameLabel��$��
Start Game��$��Center=�$��Center=�$��48(��� $ 
Horizontal=�$��Center=�$��0,20,0,0q�.+��� -   $ NumberPlayersLabel��$��Number of Players:��$��0,0,50,0q�$��18(��� -    ��Name$ _2PlayersButton��$��2��$��Center=�$��30��$��30��$��Center=�$
��10,3q�$��18(��� -   $ _3PlayersButton��$��3��$��Center=�$��30��$��30��$��Center=�$
��10,3q�$��18(��� -   $ _4PlayersButton��$��4��$��Center=�$��30��$��30��$��Center=�$
��10,3q�$��18(��� -   $ MiddleStackPanel��$ 
Horizontal=�$	��180��$��Center=�.+��� $ Vertical=�$��Center=�$��Center=�$��	20,0,50,0q�.+��� -	   $ Player1Label��$��Player 1��$��18(�$y�Hidden=��� -
   $ Player2Label��$��Player 2��$��18(�$y�Hidden=��� -   $ Player3Label��$��Player 3��$��18(�$y�Hidden=��� -   $ Player4Label��$��Player 4��$��18(�$y�Hidden=��� $ Vertical=�$��Center=�$��Center=�$��0,0,25,0q�.+��� -   	 ��Name$	 Player1Name��$��Player 1 Name��$��Center=�$��Center=�$	��0,3q�$��18(�$y�Hidden=�$	��165���� -   $	 Player2Name��$��Player 2 Name��$��Center=�$��Center=�$	��0,3q�$��18(�$y�Hidden=�$	��165���� -   $	 Player3Name��$��Player 3 Name��$��Center=�$��Center=�$	��0,3q�$��18(�$y�Hidden=�$	��165���� -   $	 Player4Name��$��Player 4 Name��$��Center=�$��Center=�$	��0,3q�$��18(�$y�Hidden=�$	��165���� $��Center=�$��Center=�.+�#  Xceed.Wpf.Toolkit.ColorPicker  -   
  Name$
 Player1Color��   DisplayColorAndName . $	��100��$	��0,3q�$��30��$y�Hidden=�   SelectedColor$	 Red��  -   $
 Player2Color�� . $	��100��$	��0,3q�$��30��$y�Hidden=�$
 Blue��  -   $
 Player3Color�� . $	��100��$	��0,3q�$��30��$y�Hidden=�$ Green��  -   $
 Player4Color�� . $	��100��$	��0,3q�$��30��$y�Hidden=�$ Yellow��� $��50��.+��� -   $ StartGameButton��$��
Start Game��$
��Left=�$	��Top=�$��
340,10,0,0q�$��24(�$y�Hidden=�