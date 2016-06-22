include_recipe 'quickbase-java'

remote_file "#{Chef::Config['file_cache_path']}/#{node['tomcat']['file']}" do
  source node['tomcat']['url']
  checksum node['tomcat']['checksum']
end

user 'tomcat' do
  shell '/bin/nologin'
end

directory node['tomcat']['install_dir'] do
  owner 'root'
  group 'root'
  mode 0755
end

tar_extract "#{Chef::Config['file_cache_path']}/#{node['tomcat']['file']}" do
  action :extract_local
  target_dir node['tomcat']['install_dir']
  creates "#{node['tomcat']['install_dir']}/LICENSE"
  tar_flags ['--strip-components 1']
end

directory "#{node['tomcat']['install_dir']}/conf" do
  mode 0770
  owner 'root'
  group 'tomcat'
end

%w(catalina.policy catalina.properties context.xml tomcat-users.xml tomcat-users.xsd web.xml).each do |file|
  file "#{node['tomcat']['install_dir']}/conf/#{file}" do
    mode 0640
    owner 'root'
    group 'tomcat'
  end
end

directory "#{node['tomcat']['install_dir']}/work" do
  mode 0700
  owner 'tomcat'
  group 'root'
end

directory "#{node['tomcat']['install_dir']}/temp" do
  mode 0700
  owner 'tomcat'
  group 'root'
end

directory "#{node['tomcat']['install_dir']}/logs" do
  mode 0700
  owner 'tomcat'
  group 'root'
end

node['tomcat']['delete_directories'].each do |dir|
  directory "#{node['tomcat']['install_dir']}/#{dir}" do
    action :delete
    recursive true
  end
end

template "#{node['tomcat']['install_dir']}/conf/server.xml" do
  source 'server.xml.erb'
  mode 0640
  owner 'root'
  group 'tomcat'
end

directory "#{node['tomcat']['install_dir']}/webapps" do
  mode 0755
  owner 'tomcat'
  group 'tomcat'
end

template "#{node['tomcat']['install_dir']}/conf/logging.properties" do
  source 'logging.properties.erb'
  mode 0640
  owner 'root'
  group 'tomcat'
end

template '/etc/sysconfig/tomcat' do
  source 'sysconfig-tomcat.erb'
  mode 0644
  owner 'root'
  group 'root'
  variables(
    java_options: node['tomcat']['java_options'],
    catalina_options: node['tomcat']['catalina_options'],
    java_home: ENV['JAVA_HOME'],
    environment: node['tomcat']['environment']
  )
end

template '/usr/lib/systemd/system/tomcat.service' do
  source 'tomcat.service.erb'
  mode 0444
  owner 'root'
  group 'root'
end

template '/usr/lib/systemd/system/tomcat-keygen.service' do
  source 'tomcat-keygen.service.erb'
  mode 0444
  owner 'root'
  group 'root'
end

service 'tomcat' do
  action :enable
end

service 'tomcat-keygen' do
  action :enable
end

remote_file "#{node['tomcat']['install_dir']}/webapps/#{node['tomcat']['app_deploy']['context_name']}.war" do
  source node['tomcat']['app_deploy']['artifact']
  owner 'tomcat'
  group 'tomcat'
end

service 'tomcat' do
  action :start
end

service 'tomcat-keygen' do
  action :start
end
