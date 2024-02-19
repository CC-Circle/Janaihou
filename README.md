# このゲームの説明
- 目次
	- 特定のクラスの説明
		- [TIME_MANAGER](#TIME_MANAGER)
## お知らせ
2/19
このリポジトリのプロジェクトデータは大きいためクローンに失敗する可能性があります
その際はターミナルに以下を打ち込んでクローンしてみてください
- ```git clone --filter=blob:none https://github.com/CC-Circle/Janaihou.git```
- でパーシャルクローンすることで fetch してくるデータサイズを小さくすることができます
- 参考
  - https://qiita.com/irgaly/items/0aace5cbd44aa4220733

## TIME_MANAGER
### このクラスでは時間の正進行と逆行を管理している

-  クラス内に時間の正進行と逆行を総括する変数を設けた
#### is_revtime　

<details>
<summary>is_revtimeの詳細</summary>



初期値はfalse
```
public static bool is_revtime = false;
```

|型|trueの時想定される挙動|falseの時想定される挙動|
|:--:|:--:|:--:|
|public static bool|時間が逆行している|通常の進行|

現状はそれぞれのギミックで時間の正進行と逆行を管理していると思われるが
今後は効率の良い開発のために __is_revtime__ を参照しての時間進行の管理を行ってもらいたい

赤字部分→緑字部分のように判定部分を変更するとTIME_MANAGERを利用できる

```diff
- if(各自で考えた時間管理フラグ)
- {
	それぞれのギミックの挙動
- }

+ if(TIME_MANAGER.isrevtime)
+ {
	それぞれのギミックの挙動
+ }
```

</details>

### 逆行を行える時間の制限



- 時間の逆行が可能な量をコントロールできるようにした
（これはゲーム性の向上を狙ってのことである）

画像： <img width="500" alt="https://cf057251.cloudfree.jp/pic/inspec_TIME_MANAGER.png" src="https://cf057251.cloudfree.jp/pic/inspec_TIME_MANAGER.png">

<details>
<summary>詳細</summary>

量の調節はTIME_MANAGERの　__max_clock__　の値を
インスペクターから変更することによって行う

```
public int max_clock = 20;
```


残量は画面上部のゲージにて試験的に確認できるが最終的なUIデザインは要相談
ゲージの挙動の様子は　__stage_add_rock__ シーンにて確認することができる

その他オプションとして

```
public bool Force_change = false;
```
を用意した　
インスペクター上の

チェックボックスのon / offで切り替えることができる

|trueの時想定される挙動|falseの時想定される挙動|
|:--:|:--:|
|制限量を超えた時強制的に時間逆行が解除される|次にスペースキーを押すまでは逆行は解除されない|


</details>

# ステージ２の追加

歯車のステージを作成中

<img width="400" alt="スクリーンショット 2024-02-07 16 56 57" src="https://github.com/MMD-Lucky/zyanaihou/assets/136224249/0e018eab-4157-4ae0-a784-b509b2ef12bf">


