   M S B A M L   `   `   `  ����H  DgalerijaSlika, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:galerijaSlika.FormegalerijaSlika.Forme  5   	   %    galerijaSlika.Forme.FrmUlaznica   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:galerijaSlika.Forme     5   	     � Title$  Ulaznica��5   	   $	��217��6   $	��350��6'   $��14(�5	      ���#4d0000.��5      � $	��222��6   $	��Top=�6   ��5   
   �� 5       j� Stretch$
 Fill=�6    �� ImageSource$ ulaznica.png��6(    j� 
AlignmentX$ Center=�6C    j� 
AlignmentY$	 Top=�6W   6j   .+�5   
   �� -   5        $��
btnSacuvaj��5      $��Sačuvaj��6#   ���#3a1313$��Medium"�6J   $
��Left=�6^   $��
16,167,0,0q�6y   $	��Top=�6�   $��75��6�    � 	Resources 5       �� 
TargetType �� Property �� Value��%_   '��       �� 5      " ��6   .�5      ��  �@��CornerRadius$ 10��65   5      5      5      �� 5   
   -   5        $��	btnOtkazi��5      $��Otkaži��6"   ���#3a1313$��Medium"�6H   $
��Left=�6\   $��257,167,0,0q�6w   $	��Top=�6�   $��75��6�    5      ��%_   '��       �� 5      " ��6   .�5      ��  �@��CornerRadius$ 10��65   5      5      5       �� 5!   
   -   5        $��txtCenaUlaznice��5!      $��Center=�6)   $��23��6F   $��0,18,0,0q�6R   	 �� TextWrapping$
	 Wrap=�6d   $��Italic$�6x   
�������$��Unesite cenu��6�   $	��Top=�6�   $	��120��6�   �� 5#   
   -   5        $��cbPosetilac��5#      
 �� DisplayMemberPath$
 	posetilac��6&    �� SelectedValuePath$ posetilacID��6D   $
��Left=�6d   $��	10,66,0,0q�6   $	��Top=�6�   $��81��6�    J� RenderTransformOrigin$ 0.483,2.425&�6�   $��23��6�   �� 5$   
   $��
Posetilac:��6   $
��Left=�6%   $��	10,41,0,0q�6@   $	��Top=�6S   �� 5&   
   -   5        $��
cbKorisnik��5&      $
 korisnik��6%   $ 
korisnikID��6B   $
��Left=�6a   $��
131,66,0,0q�6|   $	��Top=�6�   $��77��6�   $��23��6�   �� 5'   
   $��	Korisnik:��6   $
��Left=�6$   $��
131,41,0,0q�6?   $	��Top=�6S   �� 5)   
   $��243,61,28,128q�6   .��5*      �� -   5        $��	cbIzlozba��5*      $
 izlozba��6(   $ 	izlozbaID��6D   $��69��6b   $��25��6m   5+      �� 5,   
   $��Izlozba:��6   $
��Left=�6#   $��
254,41,0,0q�6>   $	��Top=�6R   5/      50      