   M S B A M L   `   `   `  ����J  FTakeHomeMidterm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:TakeHomeMidtermTakeHomeMidterm  5   	   !    TakeHomeMidterm.LoginWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:TakeHomeMidterm     5   	   -   5          � Title$  LoginWindow��5   	   $	��200��6   $	��400��6*    � WindowStartupLocation$ CenterScreen=�6M    � 
ResizeMode$ NoResize=�6r   .��5	      � ���#33ffcc J� RenderTransformOrigin$ 0.501,0.451&�6!    � ColumnDefinitions 5
   
   �� 5      $��1* �6   6,   �� 5      $��2* �6   6,    � RowDefinitions 5   
   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   .+�5   
   �� -   5         ��Name$ label��5      $��	Username:��6   $
��Left=�63   $��	58,22,0,0q�6N   $	��Top=�6a   $��83��6y   $��2��6�   �� 5   
   -   5        $ label1��5      $��	Password:��6    $��Right=�64   $��0,49,10.2,0q�6P   $	��Top=�6e   $ 	-1.427,-1&�6}   �� 5   
   -   5         ��Name$ 
tbUsername��5      $
��Left=�6&   $��23��6A   $��
131,27,0,0q�6M    �� TextWrapping$
 Wrap=�6a   $�� ��6u   $	��Top=�6}   $	��218��6�   $��2��6�   G� 5   
   -   5        	 G�Name$	 
pbPassword��5      $
��Left=�6*   $��
131,55,0,0q�6E   $	��Top=�6Y   $	��218��6q   $��2��6}   $��25��6�   �� 5   
   -   5        
 ��Name$
 btnLogin��5      $��_Login��6#   $��1��64   $
��Left=�6D   $��12.8,3.4,0,0q�6_   $��1��6u   $	��Top=�6�   $��89��6�   $��29��6�   6�   �� 5   
   -   5        $
 	tbnCancel��5      $��_Cancel��6$   $��1��66   $
��Left=�6F   $��114.8,3.4,0,0q�6a   $��1��6x   $	��Top=�6�   $��94��6�   $��29��6�   6�   5      5      