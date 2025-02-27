Lift Engine
@ 2018 Niwashi Games
Version 1.1

Lift Engine は動く床や回転する床を
作ることができるツールです。

[Move Lift]
パスを設定して床を動かします。

[Rotate Lift]
角度を設定して床を回転させます。

[Wheel Lift]
観覧車のように床を動かします。

[Base Transform]
'Transform'の代わりにつかいます。
'Lift'の'Preview'がオンになっているときは'Base Transform'を基準に動きます。

[Ride Surface]
キャラクターや他のオブジェクトを乗せる範囲を設定します。

■使い方
1.'Component -> Lift Engine'からコンポーネントを追加します。
2.'Inspector'でそれぞれパラメータを設定します。

- スクリプトから動かしたい場合
1.'using GimmickEngine.Lift'を書きます。
2.リフトのコンポーネントを取得します。
3.Play関数で動かし、Stop関数で止めます。

■バージョン履歴
1.1
- ListBase を LiftBase に修正
- MoveLiftLite を追加
- WheelLift を追加
- BaseTransform の名前空間を GimmickEngine.Lift.Core から GimmickEngine.Core に変更。
1.0
- 初期バージョン