   M S B A M L   `   `   `  ����B  >WpfApp2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp2WpfApp2  5   	       WpfApp2.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp2     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �� .+�5
   
   �� $��
Biblioteca��6   $��Center=�6%   $��0,10,0,0q�6B   $	��Top=�6T   $��26��6l   $��62��6x   �� 5   
   -   5         ��Name$ list_listable��5      $��	10,10,0,0q�6U   $	��100��6�    �� SelectedItem 6h   �� *ItemSelecionado+��6�   �� *ListaListable+ �� View 5      �� 5      .P�5      �� $��Codigo��6%    �� DisplayMemberBinding 65   ��  �� Path$ Codigo��� 5      $
��Nome��6%    63   �� $
 Nome�5      5      �� 5   
   -   5         ��Name$ cmb_type��5   <   $��0,10,0,0q�6N   $��Center=�6`   $	��Top=�6}   $	��120��6�   $��22��6�    6   �� *TipoSelecionado+.@�5         WpfApp2.TipoItem 
Pessoa=�6%    5      	Livro=�6$   5      �� 5   
   $��Incluir��6)   $
��Left=�6;   $��	10,10,0,0q�6V   $	��Top=�6i   $��20��6�   $��36��6�   ��6   �� *Add+6�   �� 5   
   $��Remover��6,   $
��Left=�6>   $��	10,10,0,0q�6Y   $	��Top=�6l   $��20��6�   $��51��6�   ��6   �� *Remove+6�   �� 5   
   $��Alterar��6,   $
��Left=�6>   $��	10,10,0,0q�6Y   $	��Top=�6l   $��20��6�   $��39��6�   ��6   �� *Update+6�   �� 5   
   $��	Emprestar��6/   $
��Left=�6C   $��	10,10,0,0q�6^   $	��Top=�6q   $��20��6�   $��57��6�   ��6   �� *	Emprestar+6�   �� 5   
   $��Devolver��6.   $
��Left=�6A   $��	10,10,0,0q�6\   $	��Top=�6o   $��20��6�   $��51��6�   ��6   �� *
Devolver+6�   �� 5   
   $��Informacoes��6*   $
��Left=�6@   $��	10,10,0,0q�6[   $	��Top=�6n   ��6   �� *Info+6n   5      5      