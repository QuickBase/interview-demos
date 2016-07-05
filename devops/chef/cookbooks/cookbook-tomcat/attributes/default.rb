default['tomcat']['install_dir'] = '/opt/tomcat'
default['tomcat']['delete_directories'] = %w(webapps/docs webapps/host-manager webapps/manager webapps/ROOT webapps/examples)
default['tomcat']['version']          = '8.0.36'
default['tomcat']['file']             = "apache-tomcat-#{node['tomcat']['version']}.tar.gz"
default['tomcat']['url']              = "http://quickbase-interview-files.s3-website-us-west-2.amazonaws.com/#{node['tomcat']['file']}"
default['tomcat']['checksum']         = '7963464d86faf8416b92fb2b04c70da9759c7c332e1700c1e9f581883b4db664'
default['tomcat']['java_options']     = '-Djava.awt.headless=true -Djava.security.egd=file:/dev/./urandom'
default['tomcat']['catalina_options'] = '-Xms512M -Xmx1024M -server -XX:+UseParallelGC'
default['tomcat']['environment']      = []
default['tomcat']['app_deploy']['context_name'] = 'demo'
default['tomcat']['app_deploy']['clean_directories'] = %w(temp logs work)
default['tomcat']['app_deploy']['artifact'] = 'file:///tmp/user-service-1.0-SNAPSHOT.war'
