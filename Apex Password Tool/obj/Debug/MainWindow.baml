   M S B A M L   `   `   `  ����^  ZApex Password Generator, Version=0.0.0.1, Culture=neutral, PublicKeyToken=c2819dd389c869caA%clr-namespace:Apex_Password_GeneratorApex_Password_Generator  5   	   (    "Apex_Password_Generator.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Apex_Password_Generator     5   	     � Title$#  Apex Quick Password Generator��5   	   $��419.969��6/   $��373.565��6@    � 
ResizeMode$ CanMinimize=�6P    � Icon$G A202-2022896_password-icon-free-download-png-svg-show-password.png��6i   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��52* �6   �� 5      $
��339* �6    � ColumnDefinitions 5   
   �� 5      �� 5      $��0* �6   .+�5   
   �� ���	#FFF4F4F5$
��Left=�6%   $	��252��6@   $��	10,53,0,0q�6M   
���   �$	��Top=�6o   $	��338��6�   $��1��6�   �� 5   
   -   5         ��Name$ 	numSlider��5      $
��Left=�6$   $��55��6?   $��	30,89,0,0q�6K   $	��Top=�6^   $	��293��6v    � Maximum$ 30Q�6�   $��1��6�   �� 5   
   -   5         ��Name$ numText��5      $
��Left=�6#   $��20��6>   $��
77,130,0,0q�6J   $	��Top=�6^   $	��186��6v    �� TextWrapping$
 Wrap=�6�   $��30��6�   	 �� TextAlignment$	 Center=�6�   $��1��6�   �� 5   
   -   5        
 ��Name$

 Logo��5      $
��Left=�6   $	��100��69   $��	10,10,0,0q�6F   $	��Top=�6Y   $	��100��6q   $��2��6}   �� 5   
   $��12,13,201,286q�6   $��Apex-Logo.jpg��6'   $
��Fill=�6>   $��2��6M   �� 5   
   -   5         ��Name$ button��5      $��	Randomize��6!   $
��Left=�65   $��23��6P   $��111,176,0,0q�6\   $	��Top=�6q   $	��119��6�   $��1��6�   �� 5   
   -   5        $ passBox��5      $
��Left=�6#   $��38��6>   $��
31,220,0,0q�6J   $
 Wrap=�6^   $	��Top=�6r   $	��293��6�   $	 Center=�6�   $��1��6�   $��16(�6�   �� 5   
   -   5        $ btnCopy��5      $��Randomize & Copy��6"   $
��Left=�6A   $��111,271,0,0q�6\   $	��Top=�6q   $	��119��6�   $��20��6�   $��1��6�   �� 5   
   $��   Password Length��6   $
��Left=�6-   $��
106,58,0,0q�6H   $	��Top=�6\   $��26��6t   $	��131��6�   $��1��6�   �� 5   
   $��Quick Password Generator��6   $
��Left=�63   $��
159,26,0,0q�6N   $	��Top=�6b   $��Candara)�6z   $��16(�6�   $��1��6�   �� 5   
   -   5         ��Name$ Version��5      $��Version 0.02��6!   $
��Left=�68   $��274,305,0,0q�6S   $	��Top=�6h   $��1��6�   5      5       