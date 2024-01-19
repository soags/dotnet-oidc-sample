# .NET OIDC サンプル

## 構成
- HTML+JavaScript: クライアントは純粋なHTML+JavaScript
- ASP.NET Core Web API: 基本的にAPIサーバー、Webサーバーも兼ねる
- Keycloak: OIDC認証サーバー、サンプルなのでDockerでサクッと立てる

## 事前準備

https://www.keycloak.org/getting-started/getting-started-docker

### KeycloakをDockerで立ち上げる
```docker
docker run -p 8080:8080 -e KEYCLOAK_ADMIN=admin -e KEYCLOAK_ADMIN_PASSWORD=admin quay.io/keycloak/keycloak:23.0.4 start-dev
```

管理コンソール：http://localhost:8080/admin
管理ユーザー: admin/admin

### Realmを作成
1. 管理コンソールの左上隅にある「master」という単語をクリックし、 「レルムの作成」をクリック
1. 「レルム名」に”myrealm”を入力して作成

### ユーザーを作成
1. 左側メニューで「ユーザー」を選択
1. 「ユーザーの追加」をクリック
1. フォームにテストユーザー情報を入力して作成
1. ページ上部の「認証情報」をクリック
1. パスワードを設定
    - "Temporary"はオフにしておく

### クライアントの設定
1. 「クライアントの作成」からクライアントを作成する
    - クライアントID: test-oidc
    - 有効なリダイレクトURI: https://localhost:7161/* (ASP.NETのURL)
    - Webオリジン: https://localhost:7161 (ASP.NETのオリジン)

### クライアントシークレットの設定
1. ソース上のkeycloakClientSecretを適宜設定する
   - クライアント/<クライアントID>/クレデンシャル/クライアント・シークレット

**※ このリポジトリはKeycloakをDockerで毎回ゼロ起動するため問題ないが、シークレットは公開してはいけない**
