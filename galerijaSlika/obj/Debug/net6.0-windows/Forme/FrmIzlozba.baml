   M S B A M L   `   `   `  ����H  DgalerijaSlika, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:galerijaSlika.FormegalerijaSlika.Forme  5   	   $    galerijaSlika.Forme.FrmIzlozba   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:galerijaSlika.Forme     5   	     � Title$  Podaci o izlozbi��5      $	��217��6    $	��350��6-   $��14(�5	      ���#4d0000.��5      � $	��222��6   $	��Top=�6   ��5   
   �� 5       j� Stretch$
 Fill=�6    �� ImageSource$ izlozba.png��6(    j� 
AlignmentX$ Center=�6B    j� 
AlignmentY$	 Top=�6V   6i   .+�5   
   �� -   5        $��
btnSacuvaj��5      $��Sačuvaj��6#   ���#3a1313$��Medium"�6J   $
��Left=�6^   $��
16,133,0,0q�6y   $	��Top=�6�   $��75��6�    � 	Resources 5       �� 
TargetType �� Property �� Value��%_   '��       �� 5      " ��6   .�5      ��  �@��CornerRadius$ 10��65   5      5      5      �� 5   
   -   5        $��	btnOtkazi��5      $��Otkaži��6"   ���#3a1313$��Medium"�6H   $
��Left=�6\   $��
16,168,0,0q�6w   $	��Top=�6�   $��75��6�    5      ��%_   '��       �� 5      " ��6   .�5      ��  �@��CornerRadius$ 10��65   5      5      5      (  "System.Windows.Controls.DatePicker  5    
   -   5        $��dpDatumOtvaranja��5       $��Center=�6-   $��0,19,0,0q�6J   $	��Top=�6\   �� 5!   
   $��Datum otvaranja��6   $
��Left=�6*   $��	-3,19,0,0q�6E   $	��Top=�6X     5#   
   -   5        $��dpDatumZatvaranja��5#      $
��Left=�6.   $��227,169,0,0q�6I   $	��Top=�6^   �� 5$   
   $��Datum zatvaranja��6   $
��Left=�6+   $��104,165,0,0q�6F   $	��Top=�6[   �� 5'   
   -   5        $��	cbIzlagac��5'      	 �� DisplayMemberPath$	 izlagac��6$   
 �� SelectedValuePath$
 	izlagacID��6@   $
��Left=�6^   $��
257,41,0,0q�6y   $	��Top=�6�   $��63��6�   $��18��6�   �� 5(   
   $��Izlagac��6   $
��Left=�6"   $��
257,12,0,0q�6=   $	��Top=�6Q   5,      5-      