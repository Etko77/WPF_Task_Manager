   M S B A M L   `   `   `  ����F  BTaskManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:TaskManager.ViewsTaskManager.Views  5   	   7 clr-namespace:TaskManager.ModelsTaskManager.Models  5   	   %    TaskManager.Views.NewTaskWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:TaskManager.Views     5   	   3models clr-namespace:TaskManager.Models     5   	     � Title$  New Task��5	   	   $	��600��6   $	��600��6'   $	��600��5
       � WindowStartupLocation$ CenterScreen=�5   	   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��Create New Task��6      Heading1#��[  5      $��0,0,0,20q�5      �� 5   
   $��1��6   $��0,0,0,10q�6"   .+�5      �� $��Title��6   $��0,0,0,5q�6%   �� 5      -   5         ��Name$ TitleTextBox��5        TaskListSearchBox#��[ 5       $��40��5!      5"      �� 5$   
   $��2��6   $��0,0,0,10q�6"   .+�5%      �� $��Description��6   $��0,0,0,5q�6+   �� 5&      -   5        $ DescriptionTextBox��5&      #��[ 5'      $��60��5(       �� TextWrapping$
 Wrap=�5)       �� AcceptsReturn . 5*      5+      �� 5-   
   $��3��6   $��0,0,0,10q�6"   .+�5.      �� $��Due Date��6   $��0,0,0,5q�6(   (  "System.Windows.Controls.DatePicker  5/      -   5          Name$ DueDatePicker��5/      $��40��50      51      52      �� 54   
   $��4��6   $��0,0,0,10q�6"   .+�55      �� $��
Importance��6   $��0,0,0,5q�6*   �� 56      -   5         ��Name$ ImportanceComboBox��56      $��40��57      .@�59      �� $	��Low��6   �� 5:      $��Medium��6   �� 5;      $
��High��6   �� 5<      $��Critical��6   5=      5>      �� 5@   
   $��5��6   $��0,0,0,10q�6"   .+�5A      �� $��Category��6   $��0,0,0,5q�6(   �� 5B      -   5        $ CategoryComboBox��5B      $��40��5C      .@�5E      �� $��Personal��6   �� 5F      $
��Work��6   �� 5G      $
��Home��6   �� 5H      $��Travel��6   �� 5I      $��Health and Wellbeing��6   �� 5J      $��Finance��6   �� 5K      $��Shopping��6   �� 5L      $��Social��6   �� 5M      $��	Education��6   �� 5N      $��Errands��6   �� 5O      $��Hobbies and Leisure��6   �� 5P      $ ��Birthday and Anniversaries��6   �� 5Q      $��Projects��6   �� 5R      $ ��Volunteering and Community��6   5S      5T      �� 5V   
   $��7��6    �� Orientation$ 
Horizontal=�5W      $��Right=�5X      .+�5Y      �� -   5        $��Cancel��5Y        TaskViewDeleteButton#��[ 5Z      $	��120��5[      $��0,0,10,0q�5\      5]      �� 5^      -   5        $��Create Task��5^        TaskViewCompleteButton#��[ 5_      $	��120��5`      5a      5b      5c      5d      