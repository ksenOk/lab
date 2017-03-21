# lab
## Постановка задачи:
Происходит противостояние двух армий, в каждой из которых есть  участники  боя - unit, соответствующие иерархии приведенной ниже. 
![Image alt](https://github.com/ksenOk/lab/blob/master/1.jpg)

У каждого юнита есть следующие атрибуты: инициатива, здоровье и сила.
Бой происходит согласно следующим правилам:
1)	У каждого юнита есть свой максимальный уровень здоровья:
	* Воин-5;
	*	Ковалерия-10;
	*	Лучник-3;
	*	Конный лучник-7;
	*	Лекарь-3;
	*	Лечащая башня-20;
	*	Атакующая башня-30;
2)	Некоторые юниты могут атаковать  определенной силой:
	*	Воин-2;
	*	Ковалерия-7;
	*	Лучник-3;
	*	Конный лучник-10;
	*	Атакующая башня-20;
3)	Некоторые юниты могут восстанавливать других на определенный уровень единиц здоровья:
	*	Лекарь может вылечить не более 1 юнита,  не более чем на 2 единицы здоровья;
	*	Лечащая башня может вылечить не более 3-ех юнитов, не более чем на 15 единиц здоровья за 1 ход;
4)	Юниты обладают определенной инициативой, которая определяет порядок ходов:
	*	Башни имеют инициативу 1;
	*	Конный лучник-2;
	*	Ковалерия-3;
	*	Лучник—4;
	*	Лекарь-5;
	*	Воин-6;
Чем меньше инициатива, тем больший приоритет наносить удар.
5)	На каждом ходу каждый юнит наносит урон произвольному юниту противника на уровень своей силы/лечит произвольных юнитов-союзников на уровень своей силы;
6)	Результаты боя до и после каждого хода выводятся на консоль и записываются в файл с расширением .txt, находятся в той же папке, что и исполняемы код (при желании можно изменить адрес, куда будет сохраняться файл).


## Алгоритм реализации:
1)	Создание двух армий происходит рандомно  с помощью  switch
2)	Происходит сортировка армий с помощью лямбда выражения по инициативам
3)	Затем реализуются алгоритм боя следующим образом:
	*	Берутся первые игроки каждой армии, сравниваются по инициативам, ходит игрок с наименьшей инициативой, если инициативы равны, то ход делает игрок, выбранный рандомно;
	*	Для игрока, который ходит, определяется, к какому виду войск он относится - лечащий или атакующий (для определения вида войск используется интерфейс Help, этот интерфейс наследуют Healer и HealingTower). Для лечащего проверяется  ограничения по максимальной помощи юнитам и по кол-ву единиц здоровья, на которые он может вылечить. Игроки, которым он может помочь выбираются рандомно из той же армии, что и этот игрок;
	*	Если же игрок атакующий, то выбирается рандомный игрок из противоположной армии, здоровье которого вычисляется как разность его здоровья и сила атакующего.  Если здоровье меньше или равно нулю, то игрок умирает (удаляется из списка армий);
	*	Далее рассматриваются (сравниваются инициативы) следующий воин и воин, который не сходил из противоположной армии;
	*	Бой продолжается до того момента, пока в одной из армий не умрут все игроки.
