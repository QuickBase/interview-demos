default['quickbase-java']['major_version']               = '8'
default['quickbase-java']['minor_version']               = '74'
combined_u_version                                       = "#{node['quickbase-java']['major_version']}u#{node['quickbase-java']['minor_version']}" # 8u74
combined_dot_version                                     = "1.#{node['quickbase-java']['major_version']}.0_#{node['quickbase-java']['minor_version']}" # 1.8.0_74
default['quickbase-java']['rpm_package_name']            = "jdk#{combined_dot_version}"
default['quickbase-java']['rpm_file']                    = "jdk-#{combined_u_version}-linux-x64.rpm"
default['quickbase-java']['jdk_url']                     = "http://quickbase-interview-files.s3-website-us-west-2.amazonaws.com/jdk-#{combined_u_version}-linux-x64.rpm"
default['quickbase-java']['jdk_checksum']                = 'dd11d03059f7835f7965d1db96b26e21f47b04dfe7b285ce94d64200156b3ed6'

default['quickbase-java']['install-jce-us-policy-files'] = true
jce_version = node['quickbase-java']['major_version']
default['quickbase-java']['jce_policy_file']             = "jce_policy-#{jce_version}.zip"
default['quickbase-java']['jce_url']                     = "http://quickbase-interview-files.s3-website-us-west-2.amazonaws.com/jce-policy-#{jce_version}.zip"
